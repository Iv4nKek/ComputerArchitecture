using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.PCModel.Models.ConnectionInterfaceModel;
using TestTask.PCModel.Shop;

namespace TestTask.ComputerSelling.ComputerComponentModel
{
    /*
        Для того, чтобы реализовать создание нескольких объектов одной модели без копипаста конструкторов были сделаны модели компонентов
        В основном это требуется для магазина, чтобы компоненты одной модели были в одном лоте.
     */
    public abstract class ComponentModel : IComponentModel
    {
        private String name;
        private float mass;
        protected ConnectionInterfacePool connectionInterfacePool;

        
        public string Name => name;
        public ConnectionInterfacePool ConnectionInterfacePool => connectionInterfacePool;
        public float Mass => mass;
        

        protected ComponentModel(string name, List<ConnectionInterface> connectionInterfaces, float mass)
        {
            this.name = name;
            this.mass = mass;
            connectionInterfacePool = new ConnectionInterfacePool(connectionInterfaces);
        }
        
        public ConnectionInterfacePool GetConnectionInterfacePool()
        {
            return connectionInterfacePool;
        }
    }
}