using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server;
using Server.Commands;


namespace Server
{
    

    class NubiaHelper
    {
        private static void CopyProperties(Item dest, Item src)
        {
            PropertyInfo[] props = src.GetType().GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                try
                {
                    if (props[i].CanRead && props[i].CanWrite)
                    {
                        //Console.WriteLine( "Setting {0} = {1}", props[i].Name, props[i].GetValue( src, null ) );
                        props[i].SetValue(dest, props[i].GetValue(src, null), null);
                    }
                }
                catch
                {
                    //Console.WriteLine( "Denied" );
                }
            }
        }

        public static Item CopyItem(Item original)
        {
            if (original == null)
                return null;
            bool done = false;

            Item copy = (Item)original;
            //Container pack;

            Type t = copy.GetType();

            //ConstructorInfo[] info = t.GetConstructors();
            ConstructorInfo c = t.GetConstructor(Type.EmptyTypes);
            if (c != null)
            {
                try
                {
                    //from.SendMessage( "Copie du parchemin..." );
                    object o = c.Invoke(null);

                    if (o != null && o is Item)
                    {
                        Item newItem = (Item)o;
                        CopyProperties(newItem, copy);//copy.Dupe( item, copy.Amount );
                        copy.OnAfterDuped(newItem);
                        newItem.Parent = null;

                        /*if ( cible.Backpack != null )
                            cible.Backpack.DropItem( newItem );
                        else
                            newItem.MoveToWorld( m_Owner.Location, m_Owner.Map );*/

                        /*if( newItem is BaseParchemin )
                        {
                            BaseParchemin n = newItem as BaseParchemin;
                            n.Maitrise = 0.0;
                            n.Owner = null;
                        }*/
                        return newItem;
                    }
                    //from.SendMessage( "Finie !" );
                    //cible.SendMessage("Le parchemin de la technique apprise est dans votre sac...");
                    done = true;
                }
                catch
                {
                    //from.SendMessage( "Error!" );
                    return null;
                }
            }

            if (!done)
            {
                Console.WriteLine("Unable to dupe.  Item must have a 0 parameter constructor.");
                return null;
            }
            return null;
        }
        public static NubiaCreature CopyCreature(NubiaCreature originale)
        {
            NubiaCreature copy = new Dog();
            copy.Name = originale.Name;
            copy.BaseSoundID = originale.BaseSoundID;
            copy.Hue = originale.Hue;
            copy.BodyValue = originale.BodyValue;
            copy.Str = originale.Str;
            copy.Dex = originale.Dex;
            copy.Int = originale.Int;
            copy.HitsMaxSeed = originale.HitsMax;
            copy.ManaMaxSeed = originale.ManaMax;
            copy.Hits += 5000;
            copy.Mana += 5000;
            copy.ChangeAIType(originale.AI);
            int min = originale.DamageMin;
            int max = originale.DamageMax;
            copy.SetDamage(min, max);

            copy.Fame = originale.Fame;
            copy.Karma = originale.Karma;
            copy.VirtualArmor = originale.VirtualArmor;

            for (int i = 0; i < copy.Skills.Length; ++i)
            {
                //this.Skills[i].Base = 0;
                copy.Skills[i].Base = originale.Skills[i].Value;
            }

            for (int i = 0; i < originale.Items.Count; i++)
            {
                copy.AddItem(CloneItem(originale.Items[i]));
            }

        //    copy.competenceLie = originale.competenceLie;

            return copy;
        }
        private static Item CloneItem(Item item)
        {
            Item newItem = new Item(item.ItemID);
            newItem.Hue = item.Hue;
            newItem.Layer = item.Layer;
            newItem.Name = item.Name;
            return newItem;
        }

        public static List<string> getAllClasses(string nameSpace)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            List<string> namespaceList = new List<string>();
            List<string> returnList = new List<string>();
            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == nameSpace)
                    namespaceList.Add(type.Name);
            }
            foreach (String className in namespaceList)
                returnList.Add(className);
            return returnList;
        }
        public static bool LookAt(Mobile from, Mobile target)
        {
            int direction = 4;
            int offsetx = from.X - target.X;
            int offsety = from.Y - target.Y;

            if (offsetx > 0)
                offsetx = 1;
            else if (offsetx < 0)
                offsetx = -1;

            if (offsety > 0)
                offsety = 1;
            else if (offsety < 0)
                offsety = -1;

            //from.SendMessage("OffsetX = {0} && OffsetY = {1}  // Direction: {2}", offsetx, offsety, from.Direction.ToString());


            for (int i = 0; i < m_Offsets.Length; i += 2)
            {
                int x = m_Offsets[(i) % m_Offsets.Length];
                int y = m_Offsets[(i + 1) % m_Offsets.Length];
                // from.SendMessage("Direction = " + GetDirectionFrom(direction).ToString());
                if (x == offsetx && y == offsety &&
                    (GetDirectionFrom((int)from.Direction) == GetDirectionFrom(direction) ||
                    GetDirectionFrom((int)from.Direction) == GetDirectionFrom(direction + 1) ||
                    GetDirectionFrom((int)from.Direction) == GetDirectionFrom(direction - 1)))
                    return true;

                direction++;

                if (direction > 7)
                    direction = 0;
            }
            return false;
        }
        public static Direction GetDirectionFrom(int d)
        {
            while (d >= 8)
                d -= 8;
            while (d < 0)
                d += 8;
            return ((Direction)d);
        }
        public static Point3D getRandomPointAround(Point3D p, Map map)
        {
            for (int i = 0; i < 50; i++)
            {
                int x = p.X + Utility.RandomMinMax(-1, 1);
                int y = p.Y + Utility.RandomMinMax(-1, 1);
                int z = map.GetAverageZ(x, y);
                Point3D newp = new Point3D(x,y,z);
                if( Spells.SpellHelper.FindValidSpawnLocation(map, ref newp, true) ){
                    return newp;
                }
            }
            return p;
        }
        private static int[] m_Offsets = new int[]
			{				
				0, -1,
				1, -1,
                1, 0,
                1, 1,
                0, 1,
                -1, 1,
                -1, 0
                -1, -1
			};
    }
}