using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiposCubrimientoLogic.ModelAdapter;

namespace InsurranceLogic.ModelAdapter
{
    class AdapterCreatorImpl : AdapterCreator
    {
        private static AdapterCreatorImpl instance;

        private AdapterCreatorImpl() { }
        public IAdapter getAdapter(string modelo)
        {
            switch (modelo)
            {
                case "Insurrance":
                    return new InsurranceAdapter();
                case "TiposCubrimiento":
                    return new TiposCubrimientoAdapter();
                default:
                    
                    throw new ModeloNoExisteException();
            }
        }

        public static AdapterCreatorImpl getInstance()
        {
            if (instance == null)
            {
                instance = new AdapterCreatorImpl();
            }
            return instance;
        }
    }
}