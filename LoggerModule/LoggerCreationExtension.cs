using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;


namespace LoggerModule
{
    public class LoggerCreationExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            LoggerSetup.Setup();
        }
    }
}
