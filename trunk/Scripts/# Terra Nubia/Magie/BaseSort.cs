using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Spells
{
    public abstract class BaseSort
    {
        private string mName = "Nom du sort";
        private int mRange = 15;

        public virtual bool ComposanteVerbal { get { return true; } }
        public virtual bool ComposanteGestuelle { get { return true; } }
        public virtual Item[] ComposanteMaterielle { get { return null; } }
        public virtual Item ComposanteFocaliseur { get { return null; } }


        public virtual TimeSpan Delay { get { return WorldData.TimeTour(); } }
        
        public virtual int getNiveau(ClasseType classe)
        {
            return 0;
        }


    }
}
