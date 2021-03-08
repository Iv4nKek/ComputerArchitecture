using System.Collections.Generic;
using System.Linq;
using TestTask.PCModel.Items.ComputerComponents;
using TestTask.PCModel.Items;
using TestTask.PCModel.Shop;

namespace TestTask.PCModel
{
    
    /*
     Данный класс служит для работы со всем деревом компонентов. 
     Он абстрагирован от конкретных реализаций компонентов, но не настолько, как класс Computer(который включает ещё работу с системой).
     
     Было принято решения делать систему железа через неориентированный граф с главной вершиной - материнской платой. 
     Это является более сложным в реализации, чем просто список компонентов,
     однако боле реалистичным и с более обширным функционалом.
     */
    public class Hardware : ISellable
    {
        private MotherBoard root;

        
        public Hardware(MotherBoard root)
        {
            this.root = root;
        }


        public ComputerSystem TryToTurnOn()
        {
            if (root != null)
            {
                ComputerSystem startedSystem = root.TryRun();
                if (startedSystem != null)
                {
                    startedSystem.Startup(this);
                }
                return startedSystem;
            }

            return null;
        }

        public void TurnOff()
        {
            if (root != null)
            {
                root.TurnOff();
            }
        }

        public ComputerSystem Restart()
        {
            TurnOff();
            return TryToTurnOn();
        }
        

        public T GetComponent<T>() where T : Component
        {
            return root.Establisher.GetComponent<T>();
        }
       

        public bool TryToReplaceComponent(Component newComponent, Component toReplace)
        {
            if (newComponent == null || toReplace == null || newComponent.GetType() != toReplace.GetType())
                return false;
            Component foundComponent = null;
            if (toReplace == root)
            {
                foundComponent = root;
                root = (MotherBoard)ReconnectComponent(newComponent, root);
                return root == newComponent;
            }
            else
            {
                foundComponent = root.Establisher.FindComponentInChild(toReplace);
                Component reconnected = ReconnectComponent(newComponent, toReplace);
                return reconnected == newComponent;
            }
            
        }
        
        public float GetHardwareMass()
        {
            return CollectMass(root, new List<Component>());
        }

        private float CollectMass(Component component,List<Component> visited)
        {
            visited.Add(component);
            float childMass = 0;
            foreach (var child in component.Establisher.GetConnected())
            {
                if (!visited.Contains(child))
                {
                    childMass += child.GetMass();
                }
            }
            return component.GetMass()+childMass;
        }
        
        private Component ReconnectComponent(Component newComponent, Component toReplace)
        {
            List<Component> connected = toReplace.Establisher.GetConnected();
            connected.ForEach(x=>x.Establisher.TryToDisconnect(toReplace));
            bool isNewConnected = connected.All(x => x.Establisher.TryToConnect(newComponent) != null);
            return isNewConnected ? newComponent : toReplace;
        }

        public bool IsSameModel(ISellable anotherItem)
        {
            //Т.к. сборки продаются по отдельнсти
            return false;
        }
    }
}