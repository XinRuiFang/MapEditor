using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CVmapEditor
{
    [Serializable]
    public class Decorat
    {

        public Decorat(int x, int y, string name_layer1 = "none", string name_layer2_1 = "none", string name_layer2_2 = "none", string name_layer3_1 = "none", string name_layer3_2 = "none", string name_layer3_3 = "none", string name_layer3_4 = "none", string name_layer4_1 = "none", string name_layer4_2 = "none", int dePos_layer1x = -1, int dePos_layer1y = -1, int dePos_layer2_1x = -1, int dePos_layer2_1y = -1, int dePos_layer2_2x = -1, int dePos_layer2_2y = -1, int dePos_layer3_1x = -1, int dePos_layer3_1y = -1, int dePos_layer3_2x = -1, int dePos_layer3_2y = -1, int dePos_layer3_3x = -1, int dePos_layer3_3y = -1, int dePos_layer3_4x = -1, int dePos_layer3_4y = -1, int dePos_layer4_1x = -1, int dePos_layer4_1y = -1, int dePos_layer4_2x = -1, int dePos_layer4_2y = -1, bool isCollide = false)
        {
            this.x = x;
            this.y = y;
            dePos_layer1 = new Point(dePos_layer1x, dePos_layer1y);
            dePos_layer2_1 = new Point(dePos_layer2_1x, dePos_layer2_1y);
            dePos_layer2_2 = new Point(dePos_layer2_2x, dePos_layer2_2y);
            dePos_layer2_3 = new Point(dePos_layer3_1x, dePos_layer3_1y);
            dePos_layer3_1 = new Point(dePos_layer3_2x, dePos_layer3_2y);
            dePos_layer3_2 = new Point(dePos_layer3_3x, dePos_layer3_3y);
            dePos_layer3_3 = new Point(dePos_layer3_4x, dePos_layer3_4y);
            dePos_layer4_1 = new Point(dePos_layer4_1x, dePos_layer4_1y);
            dePos_layer4_2 = new Point(dePos_layer4_2x, dePos_layer4_2y);
            this.name_layer1 = name_layer1;
            this.name_layer2_1 = name_layer2_1;
            this.name_layer2_2 = name_layer2_2;
            this.name_layer2_3 = name_layer3_1;
            this.name_layer3_1 = name_layer3_2;
            this.name_layer3_2 = name_layer3_3;
            this.name_layer3_3 = name_layer3_4;
            this.name_layer4_1 = name_layer4_1;
            this.name_layer4_2 = name_layer4_2;
            this.isCollide = isCollide;
         }

        string protectedData;

        public string ProtectedData
        {
            get { return protectedData; }
            set { protectedData = value; }
        }

        int x;

        public int X
        {
            get { return x; }
        }
        int y;

        public int Y
        {
            get { return y; }
        }

        Point dePos_layer1;

        public Point DePos_layer1
        {
            get { return dePos_layer1; }
            set { dePos_layer1 = value; }
        }

        Point dePos_layer2_1;

        public Point DePos_layer2_1
        {
            get { return dePos_layer2_1; }
            set { dePos_layer2_1 = value; }
        }
        Point dePos_layer2_2;

        public Point DePos_layer2_2
        {
            get { return dePos_layer2_2; }
            set { dePos_layer2_2 = value; }
        }

        Point dePos_layer2_3;

        public Point DePos_layer2_3
        {
            get { return dePos_layer2_3; }
            set { dePos_layer2_3 = value; }
        }
        Point dePos_layer3_1;

        public Point DePos_layer3_1
        {
            get { return dePos_layer3_1; }
            set { dePos_layer3_1 = value; }
        }
        Point dePos_layer3_2;

        public Point DePos_layer3_2
        {
            get { return dePos_layer3_2; }
            set { dePos_layer3_2 = value; }
        }
        Point dePos_layer3_3;

        public Point DePos_layer3_3
        {
            get { return dePos_layer3_3; }
            set { dePos_layer3_3 = value; }
        }

        Point dePos_layer4_1;

        public Point DePos_layer4_1
        {
            get { return dePos_layer4_1; }
            set { dePos_layer4_1 = value; }
        }
        Point dePos_layer4_2;

        public Point DePos_layer4_2
        {
            get { return dePos_layer4_2; }
            set { dePos_layer4_2 = value; }
        }

        string name_layer1;

        public string Name_layer1
        {
            get { return name_layer1; }
            set { name_layer1 = value; }
        }
        string name_layer2_1;

        public string Name_layer2_1
        {
            get { return name_layer2_1; }
            set { name_layer2_1 = value; }
        }
        string name_layer2_2;

        public string Name_layer2_2
        {
            get { return name_layer2_2; }
            set { name_layer2_2 = value; }
        }
        string name_layer2_3;

        public string Name_layer2_3
        {
            get { return name_layer2_3; }
            set { name_layer2_3 = value; }
        }
        string name_layer3_1;

        public string Name_layer3_1
        {
            get { return name_layer3_1; }
            set { name_layer3_1 = value; }
        }
        string name_layer3_2;

        public string Name_layer3_2
        {
            get { return name_layer3_2; }
            set { name_layer3_2 = value; }
        }
        string name_layer3_3;

        public string Name_layer3_3
        {
            get { return name_layer3_3; }
            set { name_layer3_3 = value; }
        }
        string name_layer4_1;

        public string Name_layer4_1
        {
            get { return name_layer4_1; }
            set { name_layer4_1 = value; }
        }
        string name_layer4_2;

        public string Name_layer4_2
        {
            get { return name_layer4_2; }
            set { name_layer4_2 = value; }
        }
        bool isCollide;

        public bool IsCollide
        {
            get { return isCollide; }
            set { isCollide = value; }
        }

        public string GetSave()
        {
            if (this.name_layer1 == "none" || this.dePos_layer1 == new Point(-1, -1))
            {
                this.name_layer1 = "none";
                this.dePos_layer1 = new Point(-1, -1);
            }
            if (this.name_layer2_1 == "none" || this.dePos_layer2_1 == new Point(-1, -1))
            {
                this.name_layer2_1 = "none";
                this.dePos_layer2_1 = new Point(-1, -1);
            }
            if (this.name_layer2_2 == "none" || this.dePos_layer2_2 == new Point(-1, -1))
            {
                this.name_layer2_2 = "none";
                this.dePos_layer2_2 = new Point(-1, -1);
            }
            if (this.name_layer2_3 == "none" || this.dePos_layer2_3 == new Point(-1, -1))
            {
                this.name_layer2_3 = "none";
                this.dePos_layer2_3 = new Point(-1, -1);
            }
            if (this.name_layer3_1 == "none" || this.dePos_layer3_1 == new Point(-1, -1))
            {
                this.name_layer3_1 = "none";
                this.dePos_layer3_1 = new Point(-1, -1);
            }
            if (this.name_layer3_2 == "none" || this.dePos_layer3_2 == new Point(-1, -1))
            {
                this.name_layer3_2 = "none";
                this.dePos_layer3_2 = new Point(-1, -1);
            }
            if (this.name_layer3_3 == "none" || this.dePos_layer3_3 == new Point(-1, -1))
            {
                this.name_layer3_3 = "none";
                this.dePos_layer3_3 = new Point(-1, -1);
            }
          
            return this.x + "|" + this.y + "|" + this.name_layer1 + "|" + this.dePos_layer1.X + "," + this.dePos_layer1.Y + "|" + this.name_layer2_1 + "|" + this.dePos_layer2_1.X + "," + this.dePos_layer2_1.Y + "|" + this.name_layer2_2 + "|" + this.dePos_layer2_2.X + "," + this.dePos_layer2_2.Y + "|" + this.name_layer2_3 + "|" + this.dePos_layer2_3.X + "," + this.dePos_layer2_3.Y + "|" + this.name_layer3_1 + "|" + this.dePos_layer3_1.X + "," + this.dePos_layer3_1.Y + "|" + this.name_layer3_2 + "|" + this.dePos_layer3_2.X + "," + this.dePos_layer3_2.Y + "|" + this.name_layer3_3 + "|" + this.dePos_layer3_3.X + "," + this.dePos_layer3_3.Y + "|" + this.isCollide;
        }
        public string GetNpcPathSave()
        {
            return this.x + "|" + this.y + "|" + this.isCollide;
        }
        public string GetObj()
        {
            return this.x + "|" + this.y;
        }
    }
}
