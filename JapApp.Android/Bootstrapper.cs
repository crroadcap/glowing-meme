using System;
namespace JapApp.Droid
{
    public class Bootstrapper
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
