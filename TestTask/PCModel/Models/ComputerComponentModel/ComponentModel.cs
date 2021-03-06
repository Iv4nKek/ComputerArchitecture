using System;
using System.Collections.Generic;
using TestTask.ComputerSelling.ConnectionInterfaces;
using TestTask.ComputerSelling.Models;
using TestTask.ComputerSelling.Models.ConnectionInterfaceModel;

namespace TestTask.ComputerSelling.ComputerComponentModel
{
    public abstract class ComponentModel : IComponentModel
    {
        protected String name;
        protected ConnectionInterfacePool connectionInterfacePool;

        public string Name => name;

        public ConnectionInterfacePool ConnectionInterfacePool => connectionInterfacePool;

        protected ComponentModel(string name, ConnectionInterfacePool connectionInterfacePool)
        {
            this.name = name;
            this.connectionInterfacePool = connectionInterfacePool;
        }

        public ConnectionInterfacePool GetConnectionInterfacePool()
        {
            return connectionInterfacePool;
        }
    }
}