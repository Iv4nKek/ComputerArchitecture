namespace TestTask.PCModel.Items
{
    public class Application
    {
        private byte[] binaryCode;

        public Application(byte[] binaryCode)
        {
            this.binaryCode = binaryCode;
        }

        public byte[] BinaryCode => binaryCode;
    }
}