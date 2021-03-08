using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.PCModel.Models.ConnectionInterfaceModel;

namespace TestTask.PCModel.Items.ComputerComponents
{
    /* Для того, чтобы не перегружать ответственностями Component (соблюдаем Single resposibility principle), я сделал
     отдеальный класс для обработки соединений компонента, которому он принадлежит.
     Возможно, использовать Dictionary было не очень хорошей идеей т.к. он не очень подоходит симантически из-за того, что нам может потребваться икать ключ по значению.
     
     Проблемой данной системы является то, что компоненты ссылаются друг на друга и это делает проблематичным их соединие/соединение. 
     Приходится писать рекурсивные функции(где нас может встретить  StakVOerflow). 
     Эта сложность даёт хорошую гибкость при использовнии, так что думаю оно того стоит.
     */
    
    public class ConnectionEstablisher
    {
        private readonly Dictionary<Component,ConnectionInterface> connections;
        private readonly Component belongs;

        
        public ConnectionEstablisher(Component belongs)
        {
            this.belongs = belongs;
            connections = new Dictionary<Component, ConnectionInterface>();
        }

        public List<Component> GetConnected()
        {
            return connections.Keys.ToList();
        }
        //где-то я это видел...
        public T GetComponent<T>() where T:Component
        {
            return (T)connections
                .Select(x => x.Key)
                .FirstOrDefault(x => x.GetType() == typeof(T));
        }
        public Component GetComponentInChild<T>() where T:Component
        {
            Component child = GetComponent<T>();
            if (child == null)
            {
                Component result = null;
                foreach (var component in connections.Keys)
                {
                    Component childComponent = component.Establisher.GetComponentInChild<T>();
                    if (childComponent != null)
                    {
                        result = childComponent;
                        break;
                    }
                }
                return result;

            }

            return child;
        }

        public Component FindComponent(Component component)
        {
            return connections
                .Select(x => x.Key)
                .FirstOrDefault(x => x == component);
        }
        public Component FindComponent(Type type)
        {
            return connections
                .Select(x => x.Key)
                .FirstOrDefault(x => x.GetType() == type);
        }
        public Component FindComponentInChild(Component component) => FindComponentInChild(component, new List<Component>(){});
 
        public Component FindComponentInChild(Component component,List<Component> visited)
        {
            visited.Add(belongs);
            Component child = FindComponent(component);
            if (child == null)
            {
                Component result = null;
                foreach (var connected in connections.Keys)
                {
                    if (!visited.Contains(connected))
                    {
                        Component childComponent = connected.Establisher.FindComponentInChild(component,visited);
                        if (childComponent != null)
                        {
                            result = childComponent;
                            break;
                        }
                    }
                 
                }
                return result;
            }
            return child;
        }

        public Component TryToConnect(Component target)
        {
            ConnectionInterfacePool belongsPool = belongs.GetModel().ConnectionInterfacePool;
            ConnectionInterfacePool targetPool = target.GetModel().ConnectionInterfacePool;
            List<ConnectionInterface> commonInterfaces = belongsPool.FindSameInterfaces(targetPool);
            foreach (var commonInterface in commonInterfaces)
            {
                Component connected = TryToConnect(target, commonInterface);
                if (connected != null)
                    return connected;
            }
            return null;
            
        }
        
        public Component TryToConnect  (Component target, ConnectionInterface connectionInterface)
        {
            ConnectionEstablisher targetEstablisher = target.Establisher;
            if (HasFreeConnectionInterface(connectionInterface) && targetEstablisher.HasFreeConnectionInterface(connectionInterface))
            {
                targetEstablisher.AddConnection(belongs,connectionInterface);
                AddConnection(target,connectionInterface);
                return target;
            }
            return null;
        }

        public void TryToDisconnect(Component component)
        {
            if (component != null && connections.Keys.Contains(component))
            {
                Disconnect(component);
                component.Establisher.Disconnect(belongs);
            }
        }
        
        public bool HasConnectionInterface(ConnectionInterface connectionInterface)
        {
            return belongs.GetModel().ConnectionInterfacePool.FindConnectionInterface(connectionInterface) != null;
        }
        
        public bool HasFreeConnectionInterface(ConnectionInterface connectionInterface)
        {
            if (!HasConnectionInterface(connectionInterface))
                return false;
            bool interfaceIsFree = connections.All(x => x.Value != connectionInterface);
            return interfaceIsFree;
        }
        
        private void Disconnect(Component component)
        {
            connections.Remove(component);
        }
        
        private void AddConnection(Component component,ConnectionInterface connectionInterface)
        {
            if (component != null)
            {
                connections.Add(component,connectionInterface);
            }
           
        }
    }
}