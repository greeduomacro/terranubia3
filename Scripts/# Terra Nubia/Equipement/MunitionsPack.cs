using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Items
{
     public class Arrow10 : Arrow
    {
         [Constructable]
         public Arrow10()
             : base(10)
         {
         }
         public Arrow10(Serial s): base(s)
         {
         }
         public override void Serialize(GenericWriter writer)
         {
             base.Serialize(writer);
         }
         public override void Deserialize(GenericReader reader)
         {
             base.Deserialize(reader);
         }
    }
     public class Bolt10 : Bolt
     {
         [Constructable]
         public Bolt10()
             : base(10)
         {
         }
         public Bolt10(Serial s)
             : base(s)
         {
         }
         public override void Serialize(GenericWriter writer)
         {
             base.Serialize(writer);
         }
         public override void Deserialize(GenericReader reader)
         {
             base.Deserialize(reader);
         }
     }
}
