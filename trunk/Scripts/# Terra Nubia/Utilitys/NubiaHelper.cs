using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Server.Mobiles;
using Server.Items;
using Server.Misc;

namespace Server
{
    

    class NubiaHelper
    {
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