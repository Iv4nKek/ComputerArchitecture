namespace TestTask.PCModel
{
    
    public class MetalCollector
    {
        private float totalMetalMass;
        
         /* Для сдачи предмета на металл лишь требуется чтобы он из него сосотоял.
         Тут по абстрагируемся от реализации объекта до лишь его Металлический свойств*/
        public void Collect(IContainsMetal someMetal)
        {
            totalMetalMass += someMetal.GetMass();
        }
        
    }
}