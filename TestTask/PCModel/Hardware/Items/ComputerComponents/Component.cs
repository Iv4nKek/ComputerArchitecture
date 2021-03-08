using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ComputerComponentModel;
using TestTask.PCModel.Shop;

namespace TestTask.PCModel.Items.ComputerComponents
{
     /*
     Здесь построена следующая иерархия: Icomponment=>Component=>ComponentRealisation
     Это позвояет реализровать базовые методы для всех компонентов компьюетара и сбора металлолома
     Такая иерархя даёт возможность использовать Component для базовых действий и соединений с другими компонентами, 
     позволяя абстрагироваться от конкретного типа компонента.
     Возможность вручную соединять и отсоединять компонент с другими делает систему очень гибкой для построения любых конфигураций ПК и их продажи.
     */
    public abstract class Component : IContainsMetal, IComponent , ISellable
    {
        protected bool enabled;
        protected ConnectionEstablisher establisher;
        protected IReadOnlyList<Type> requireComponents; 

        
        public ConnectionEstablisher Establisher => establisher;
        

        public abstract ComponentModel GetModel();

        
        protected Component() 
        {
            establisher = new ConnectionEstablisher(this);
            requireComponents = new List<Type>();
        }
        
        protected virtual bool CanRun()
        {
            foreach (var requireComponent in requireComponents)
            {
                if (establisher.FindComponent(requireComponent) == null)
                {
                    return false;
                }
            }
            return true;
        }

        public void Enable()
        {
            if (!enabled)
            {
                establisher.GetConnected().ForEach(x=>x.Enable());
                enabled = true;
            }
        }
        
        public void Disable()
        {
            if (enabled)
            {
                establisher.GetConnected().ForEach(x=>x.Disable());
                enabled = false;
            }
        }


        public float GetMass()
        {
            return GetModel().Mass;
        }

        public bool IsSameModel(ISellable anotherItem)
        {
            Component anotherComponent = (Component) anotherItem;
            if (anotherComponent != null)
            {
                return GetModel() == anotherComponent.GetModel();
            }
            else
            {
                return false;
            }
        }
    }
}