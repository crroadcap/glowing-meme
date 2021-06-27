using System;
namespace JapApp.iOS
{
    public class Bootstrapper: JapApp.Bootstrapper
    {
        public Bootstrapper()
        {
        }
        public static void Init()
        {
            var instance = new Bootstrapper();
        }
    }
}
