using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CVmapEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Define - standard
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D mapBack;
        Texture2D decoratUsing;
        Texture2D mouse;
        Texture2D tile;
        Texture2D tileborder;
        Texture2D backright;
        Texture2D selecting;
        Texture2D standdeco;
        Texture2D saveS;
        Texture2D collide;
        Texture2D bg;
        int width;
        int height;
        Rectangle camera;
        static MouseState mouseState;
        static MouseState lastmouseState;
        List<Point> dePos = new List<Point>();
        List<Decorat> maplist;
        Point mapSize;
        float zoom = 1;
        int moveSpeed = 6;
        bool layer1Show = false;
        bool layer2_1Show = false;
        bool layer2_2Show = false;
        bool layer2_3Show = false;
        bool layer3_1Show = false;
        bool layer3_2Show = false;
        bool layer3_3Show = false;
        bool layer4_1Show = false;
        bool layer4_2Show = false;
        bool layerNpcShow = false;
        bool layer1TransShow = false;
        bool layer2_1TransShow = false;
        bool layer2_2TransShow = false;
        bool layer2_3TransShow = false;
        bool layer3_1TransShow = false;
        bool layer3_2TransShow = false;
        bool layer3_3TransShow = false;
        bool layer4_1TransShow = false;
        bool layer4_2TransShow = false;

        SpriteFont Fonts_UI6;
        Decorat lastChange;
        string decoUsingClassify;
        int decoUsingNum;
        string usingDecoName = "none";
        bool showborder = true;
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        int showtime;
        bool showAlert = false;
        bool pause = false;
        Game1 game;
        bool gameActiveInit = false;
        int framesTestTime = 0;
        int updateTime = 0;
        int drawTime = 0;
        int scrollWheelValue = 0;
        bool begin = true;
        int beginTime = 0;
        float colorPc = 1f;
        bool showBg = true;
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }
        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }
        public static MouseState MouseState
        {
            get { return mouseState; }
        }
        public static MouseState LastmouseState
        {
            get { return lastmouseState; }
        }
        #endregion

        #region Define - DecoratUsings
        Texture2D DecoratsNull;
        Texture2D Buildings_1;
        Texture2D Buildings_2;
        Texture2D Buildings_3;
        Texture2D Buildings_4;
        Texture2D Buildings_5;
        Texture2D Buildings_6;
        Texture2D Buildings_7;
        Texture2D Buildings_8;
        Texture2D Buildings_9;
        Texture2D Buildings_10;
        Texture2D Buildings_11;
        Texture2D Buildings_12;
        Texture2D Buildings_13;
        Texture2D Buildings_14;
        Texture2D Buildings_15;
        Texture2D Buildings_16;
        Texture2D Buildings_17;
        Texture2D Buildings_18;
        Texture2D Buildings_19;
        Texture2D Buildings_20;
        Texture2D Buildings_21;
        Texture2D Buildings_22;
        Texture2D Buildings_23;
        int buildingsNUM = 23;
        Texture2D Decorats_1;
        Texture2D Decorats_2;
        int decoratsNUM = 2;
        Texture2D Objects_1;
        int objectsNUM = 1;
        Texture2D Terrains_1;
        Texture2D Terrains_2;
        Texture2D Terrains_3;
        Texture2D Terrains_4;
        int terrainsNUM = 4;
        int othersNUM = 0;
        #endregion

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 1024;
            Content.RootDirectory = "Content";
            game = this;
        }

        protected override void Initialize()
        {
            scrollWheelValue = Mouse.GetState().ScrollWheelValue;
            mapBack = Content.Load<Texture2D>("mapback");
            standdeco = Content.Load<Texture2D>("standdeco");
            saveS = Content.Load<Texture2D>("save");
            DecoratsNull = Content.Load<Texture2D>("Decorats/null");
            Buildings_1 = Content.Load<Texture2D>("Decorats/Buildings/1");
            Buildings_2 = Content.Load<Texture2D>("Decorats/Buildings/2");
            Buildings_3 = Content.Load<Texture2D>("Decorats/Buildings/3");
            Buildings_4 = Content.Load<Texture2D>("Decorats/Buildings/4");
            Buildings_5 = Content.Load<Texture2D>("Decorats/Buildings/5");
            Buildings_6 = Content.Load<Texture2D>("Decorats/Buildings/6");
            Buildings_7 = Content.Load<Texture2D>("Decorats/Buildings/7");
            Buildings_8 = Content.Load<Texture2D>("Decorats/Buildings/8");
            Buildings_9 = Content.Load<Texture2D>("Decorats/Buildings/9");
            Buildings_10 = Content.Load<Texture2D>("Decorats/Buildings/10");
            Buildings_11 = Content.Load<Texture2D>("Decorats/Buildings/11");
            Buildings_12 = Content.Load<Texture2D>("Decorats/Buildings/12");
            Buildings_13 = Content.Load<Texture2D>("Decorats/Buildings/13");
            Buildings_14 = Content.Load<Texture2D>("Decorats/Buildings/14");
            Buildings_15 = Content.Load<Texture2D>("Decorats/Buildings/15");
            Buildings_16 = Content.Load<Texture2D>("Decorats/Buildings/16");
            Buildings_17 = Content.Load<Texture2D>("Decorats/Buildings/17");
            Buildings_18 = Content.Load<Texture2D>("Decorats/Buildings/18");
            Buildings_19 = Content.Load<Texture2D>("Decorats/Buildings/19");
            Buildings_20 = Content.Load<Texture2D>("Decorats/Buildings/20");
            Buildings_21 = Content.Load<Texture2D>("Decorats/Buildings/21");
            Buildings_22 = Content.Load<Texture2D>("Decorats/Buildings/22");
            Buildings_23 = Content.Load<Texture2D>("Decorats/Buildings/23");
            Decorats_1 = Content.Load<Texture2D>("Decorats/Decorats/1");
            Decorats_2 = Content.Load<Texture2D>("Decorats/Decorats/2");
            Objects_1 = Content.Load<Texture2D>("Decorats/Objects/1");
            Terrains_1 = Content.Load<Texture2D>("Decorats/Terrains/1");
            Terrains_2 = Content.Load<Texture2D>("Decorats/Terrains/2");
            Terrains_3 = Content.Load<Texture2D>("Decorats/Terrains/3");
            Terrains_4 = Content.Load<Texture2D>("Decorats/Terrains/4");

            decoratUsing = Buildings_1;
            decoUsingClassify = "Buildings_";
            decoUsingNum = 1;
            //maplist_0 = new List<Decorat>(maplist);
            //maplist_1 = new List<Decorat>(maplist);
            //maplist_2 = new List<Decorat>(maplist);
            //maplist_3 = new List<Decorat>(maplist);
            //maplist_4 = new List<Decorat>(maplist);
            //maplist_5 = new List<Decorat>(maplist);
            mouse = Content.Load<Texture2D>("UI_mouse_status");
            tile = Content.Load<Texture2D>("tile");
            tileborder = Content.Load<Texture2D>("tileborder");
            backright = Content.Load<Texture2D>("backright");
            selecting = Content.Load<Texture2D>("selecting");
            collide = Content.Load<Texture2D>("collide");
            maplist = new List<Decorat>();           
            Fonts_UI6 = Content.Load<SpriteFont>("UI6");
            bg = Content.Load<Texture2D>("bg");
            dePos.Add(new Point(-1, -1));
            Load();

            //mapSize = new Point(40, 30);
            //for (int i = 0; i < 40; i++)
            //{
            //    for (int j = 0; j < 30; j++)
            //    {
            //        maplist.Add(new Decorat(i, j));
            //    }
            //}
            
            base.Initialize();
            
        }

        protected override void LoadContent()
        {          
            width = Window.ClientBounds.Width;
            height = Window.ClientBounds.Height;
            camera = new Rectangle(0, 0, width - 300, height);
            spriteBatch = new SpriteBatch(GraphicsDevice);          
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            //updateTime++;
            if (begin)
            {
                beginTime += gameTime.ElapsedGameTime.Milliseconds;
                if (beginTime > 1500)
                {
                    begin = false;
                }
            }
            else
            {
                if (showBg)
                {
                    if (colorPc > 0)
                    {
                        colorPc -= 0.02f;
                    }
                    else
                    {
                        showBg = false;
                    }
                }
                lastmouseState = mouseState;
                mouseState = Mouse.GetState();
                lastKeyboardState = keyboardState;
                zoom += (Mouse.GetState().ScrollWheelValue - scrollWheelValue) * -1f / 1200f;
                scrollWheelValue = Mouse.GetState().ScrollWheelValue;
                keyboardState = Keyboard.GetState();
                if (!game.IsActive)
                {
                    if (gameActiveInit)
                    {
                        pause = true;
                    }
                    else
                    {
                        gameActiveInit = true;
                    }
                }
                if (!pause)
                {
                    CheckMove();
                    KeysOperate();
                    if (KeyPressed(Keys.X) || mouseState.RightButton == ButtonState.Pressed && lastmouseState.RightButton == ButtonState.Released)
                    {
                        dePos.Clear();
                        dePos.Add(new Point(-1, -1));
                    }
                    if (KeyPressed(Keys.V))
                    {
                        if (showborder)
                        {
                            showborder = false;
                        }
                        else
                        {
                            showborder = true;
                        }
                    }
                    if (lastKeyboardState.IsKeyDown(Keys.LeftControl) && KeyPressed(Keys.S))
                    {
                        Save();
                        NpcPathSave();
                    }

                    //  if (mouseState.LeftButton == ButtonState.Pressed) -- if you want to use add without released func
                    if (mouseState.LeftButton == ButtonState.Pressed && lastmouseState.LeftButton == ButtonState.Released)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.LeftShift) && lastmouseState.LeftButton == ButtonState.Released)
                        {
                            if (width - 400 < mouseState.X && mouseState.X < width && 0 < mouseState.Y && mouseState.Y < height)
                            {
                                RemoveChosen();
                            }
                            else
                            {
                                if (lastChange != null)
                                {
                                    ConvenienceOperatation();
                                }                 
                            }

                        }
                        else
                        {
                            if (width - 400 < mouseState.X && mouseState.X < width && 0 < mouseState.Y && mouseState.Y < height && lastmouseState.LeftButton == ButtonState.Released)
                            {
                                UsingRightFunc();
                            }
                            else if (0 < mouseState.X && mouseState.X < width - 400 && 0 < mouseState.Y && mouseState.Y < height)
                            {
                                OperateTileAddition();
                            }
                        }
                    }
                    if (showAlert)
                    {
                        showtime += gameTime.ElapsedGameTime.Milliseconds;
                        if (showtime > 2000)
                        {
                            showtime = 0;
                            showAlert = false;
                        }
                    }
                }
                else
                {
                    if (game.IsActive)
                    {
                        pause = false;
                    }
                }
            }
           
            base.Update(gameTime);
        }

        void KeysOperate()
        {
            if (KeyPressed(Keys.N))
            {
                moveSpeed++;
            }
            if (KeyPressed(Keys.M))
            {
                moveSpeed--;
            }
            if (KeyPressed(Keys.D1))
            {
                if (layer1Show == false && layer1TransShow == false)
                {
                    layer1TransShow = true;
                }
                else if (layer1Show == false && layer1TransShow == true)
                {
                    layer1Show = true;
                    layer1TransShow = false;
                }
                else if (layer1Show == true && layer1TransShow == false)
                {
                    layer1Show = false;
                    layer1TransShow = false;
                }
            }
            if (KeyPressed(Keys.D2))
            {
                if (layer2_1Show == false && layer2_1TransShow == false)
                {
                    layer2_1TransShow = true;
                }
                else if (layer2_1Show == false && layer2_1TransShow == true)
                {
                    layer2_1Show = true;
                    layer2_1TransShow = false;
                }
                else if (layer2_1Show == true && layer2_1TransShow == false)
                {
                    layer2_1Show = false;
                    layer2_1TransShow = false;
                }
            }
            if (KeyPressed(Keys.D3))
            {
                if (layer2_2Show == false && layer2_2TransShow == false)
                {
                    layer2_2TransShow = true;
                }
                else if (layer2_2Show == false && layer2_2TransShow == true)
                {
                    layer2_2Show = true;
                    layer2_2TransShow = false;
                }
                else if (layer2_2Show == true && layer2_2TransShow == false)
                {
                    layer2_2Show = false;
                    layer2_2TransShow = false;
                }
            }
            if (KeyPressed(Keys.D4))
            {
                if (layer2_3Show == false && layer2_3TransShow == false)
                {
                    layer2_3TransShow = true;
                }
                else if (layer2_3Show == false && layer2_3TransShow == true)
                {
                    layer2_3Show = true;
                    layer2_3TransShow = false;
                }
                else if (layer2_3Show == true && layer2_3TransShow == false)
                {
                    layer2_3Show = false;
                    layer2_3TransShow = false;
                }
            }
            if (KeyPressed(Keys.D5))
            {
                if (layer3_1Show == false && layer3_1TransShow == false)
                {
                    layer3_1TransShow = true;
                }
                else if (layer3_1Show == false && layer3_1TransShow == true)
                {
                    layer3_1Show = true;
                    layer3_1TransShow = false;
                }
                else if (layer3_1Show == true && layer3_1TransShow == false)
                {
                    layer3_1Show = false;
                    layer3_1TransShow = false;
                }
            }
            if (KeyPressed(Keys.D6))
            {
                if (layer3_2Show == false && layer3_2TransShow == false)
                {
                    layer3_2TransShow = true;
                }
                else if (layer3_2Show == false && layer3_2TransShow == true)
                {
                    layer3_2Show = true;
                    layer3_2TransShow = false;
                }
                else if (layer3_2Show == true && layer3_2TransShow == false)
                {
                    layer3_2Show = false;
                    layer3_2TransShow = false;
                }
            }
            if (KeyPressed(Keys.D7))
            {
                if (layer3_3Show == false && layer3_3TransShow == false)
                {
                    layer3_3TransShow = true;
                }
                else if (layer3_3Show == false && layer3_3TransShow == true)
                {
                    layer3_3Show = true;
                    layer3_3TransShow = false;
                }
                else if (layer3_3Show == true && layer3_3TransShow == false)
                {
                    layer3_3Show = false;
                    layer3_3TransShow = false;
                }
            }
            if (KeyPressed(Keys.D8))
            {
                if (layer4_1Show == false && layer4_1TransShow == false)
                {
                    layer4_1TransShow = true;
                }
                else if (layer4_1Show == false && layer4_1TransShow == true)
                {
                    layer4_1Show = true;
                    layer4_1TransShow = false;
                }
                else if (layer4_1Show == true && layer4_1TransShow == false)
                {
                    layer4_1Show = false;
                    layer4_1TransShow = false;
                }
            }
            if (KeyPressed(Keys.D9))
            {
                if (layer4_2Show == false && layer4_2TransShow == false)
                {
                    layer4_2TransShow = true;
                }
                else if (layer4_2Show == false && layer4_2TransShow == true)
                {
                    layer4_2Show = true;
                    layer4_2TransShow = false;
                }
                else if (layer4_2Show == true && layer4_2TransShow == false)
                {
                    layer4_2Show = false;
                    layer4_2TransShow = false;
                }
            }
            if (KeyPressed(Keys.D0))
            {
                if (layerNpcShow)
                {
                    layerNpcShow = false;
                }
                else
                {
                    layerNpcShow = true;
                }
            }
        }

        bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) &&
            lastKeyboardState.IsKeyUp(key);
        }

        void FrameTestHandler(GameTime gameTime)
        {
            framesTestTime += gameTime.ElapsedGameTime.Milliseconds;
            if (framesTestTime > 1000)
            {
                framesTestTime = 0;
                Console.WriteLine("updateTime/frame:" + updateTime);
                Console.WriteLine("drawTime/frame:" + drawTime);
                updateTime = 0;
                drawTime = 0;
                Console.WriteLine();
            }
        }

        void RemoveChosen()
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (width - 398 + 24 * j < mouseState.X && mouseState.X < width - 400 + 24 * j + 24 && 24 * i < mouseState.Y && mouseState.Y < 24 * i + 24)
                    {
                        if (dePos.Exists(u => u.X == j && u.Y == i))
                        {
                            dePos.Remove(new Point(j, i));
                            if (dePos.Count == 0)
                            {
                                dePos.Add(new Point(-1, -1));
                            }
                        }
                    }
                }
            }
        }

        void CheckMove()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (camera.Y > 0)
                {
                    camera = new Rectangle(camera.X, camera.Y - moveSpeed, camera.Width, camera.Height);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (camera.Y < mapSize.Y * 24 * zoom - height)
                {
                    camera = new Rectangle(camera.X, camera.Y + moveSpeed, camera.Width, camera.Height);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if (camera.X < mapSize.X * 24 * zoom - width + 400)
                {
                    camera = new Rectangle(camera.X + moveSpeed, camera.Y, camera.Width, camera.Height);
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if (camera.X > 0)
                {
                    camera = new Rectangle(camera.X - moveSpeed, camera.Y, camera.Width, camera.Height);
                }
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.F) && lastKeyboardState.IsKeyUp(Keys.F))
            {
                graphics.ToggleFullScreen();
                width = Window.ClientBounds.Width;
                height = Window.ClientBounds.Height;
                camera = new Rectangle(0, 0, width - 400, height);
            }
        }

        void ConvenienceOperatation()
        {
            if (!(width - 400 < mouseState.X && mouseState.X < width && 0 < mouseState.Y && mouseState.Y < height) && dePos.Count == 1)
            {
                Vector2 truePos = new Vector2(camera.X + mouseState.X, camera.Y + mouseState.Y);
                foreach (Decorat item in maplist)
                {
                    if (item.X * 24 * zoom < truePos.X && truePos.X < (item.X * 24 + 24) * zoom && item.Y * 24 * zoom < truePos.Y && truePos.Y < (item.Y * 24 + 24) * zoom)
                    {
                        if (layerNpcShow)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j && maplist[k]!= lastChange)
                                        {
                                            if (maplist[k].IsCollide)
                                            {
                                                maplist[k].IsCollide = false;
                                            }
                                            else
                                            {
                                                maplist[k].IsCollide = true;
                                            }
                                            
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer4_2Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer4_2 = dePos[0];
                                            maplist[k].Name_layer4_2 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer4_1Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X)+Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y)+Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer4_1 = dePos[0];
                                            maplist[k].Name_layer4_1 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer3_3Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer3_3 = dePos[0];
                                            maplist[k].Name_layer3_3 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer3_2Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer3_2 = dePos[0];
                                            maplist[k].Name_layer3_2 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer3_1Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer3_1 = dePos[0];
                                            maplist[k].Name_layer3_1 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer2_3Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer2_3 = dePos[0];
                                            maplist[k].Name_layer2_3 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer2_2Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer2_2 = dePos[0];
                                            maplist[k].Name_layer2_2 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer2_1Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer2_1 = dePos[0];
                                            maplist[k].Name_layer2_1 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }
                        else if (layer1Show)
                        {
                            for (int i = lastChange.X < item.X ? lastChange.X : item.X; i <= (lastChange.X < item.X ? lastChange.X : item.X) + Math.Abs(lastChange.X - item.X); i++)
                            {
                                for (int j = lastChange.Y < item.Y ? lastChange.Y : item.Y; j <= (lastChange.Y < item.Y ? lastChange.Y : item.Y) + Math.Abs(lastChange.Y - item.Y); j++)
                                {
                                    for (int k = 0; k < maplist.Count; k++)
                                    {
                                        if (maplist[k].X == i && maplist[k].Y == j)
                                        {
                                            maplist[k].DePos_layer1 = dePos[0];
                                            maplist[k].Name_layer1 = usingDecoName;
                                        }
                                    }
                                }
                            }

                            lastChange = item;
                        }

                    }
                }
            }
        }

        void UsingRightFunc()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (width - 398 + 24 * j < mouseState.X && mouseState.X < width - 400 + 24 * j + 24 && 24 * i < mouseState.Y && mouseState.Y < 24 * i + 24)
                    {
                        if (decoratUsing != null)
                        {
                            if (dePos.Count == 1 && dePos[0] == new Point(-1, -1))
                            {
                                dePos.Clear();
                            }
                            dePos.Add(new Point(j, i));
                            usingDecoName = decoUsingClassify + decoUsingNum;
                        }
                    }
                }
            }


            if (width - 400 + 13 * 24 < mouseState.X && mouseState.X < width - 400 + 13 * 24 + 24 && 24 < mouseState.Y && mouseState.Y < 48)
            {
                zoom += 0.1f;
            }
            if (width - 400 + 15 * 24 < mouseState.X && mouseState.X < width - 400 + 15 * 24 + 24 && 24 < mouseState.Y && mouseState.Y < 48)
            {
                zoom -= 0.1f;
            }

            if (width - 400 + 13 * 24 < mouseState.X && mouseState.X < width - 400 + 16 * 24 && 24 * 3 < mouseState.Y && mouseState.Y < 24 * 4)
            {
                if (layer1Show == false && layer1TransShow == false)
                {
                    layer1TransShow = true;
                }
                else if (layer1Show == false && layer1TransShow == true)
                {
                    layer1Show = true;
                    layer1TransShow = false;
                }
                else if (layer1Show == true && layer1TransShow == false)
                {
                    layer1Show = false;
                    layer1TransShow = false;
                }
            }
            if (width - 400 + 13 * 24 < mouseState.X && mouseState.X < width - 400 + 14 * 24 && 24 * 5 < mouseState.Y && mouseState.Y < 24 * 6)
            {
                if (layer2_1Show == false && layer2_1TransShow == false)
                {
                    layer2_1TransShow = true;
                }
                else if (layer2_1Show == false && layer2_1TransShow == true)
                {
                    layer2_1Show = true;
                    layer2_1TransShow = false;
                }
                else if (layer2_1Show == true && layer2_1TransShow == false)
                {
                    layer2_1Show = false;
                    layer2_1TransShow = false;
                }
            }
            if (width - 400 + 14 * 24 < mouseState.X && mouseState.X < width - 400 + 15 * 24 && 24 * 5 < mouseState.Y && mouseState.Y < 24 * 6)
            {
                if (layer2_2Show == false && layer2_2TransShow == false)
                {
                    layer2_2TransShow = true;
                }
                else if (layer2_2Show == false && layer2_2TransShow == true)
                {
                    layer2_2Show = true;
                    layer2_2TransShow = false;
                }
                else if (layer2_2Show == true && layer2_2TransShow == false)
                {
                    layer2_2Show = false;
                    layer2_2TransShow = false;
                }
            }
            if (width - 400 + 15 * 24 < mouseState.X && mouseState.X < width - 400 + 16 * 24 && 24 * 5 < mouseState.Y && mouseState.Y < 24 * 6)
            {
                if (layer2_3Show == false && layer2_3TransShow == false)
                {
                    layer2_3TransShow = true;
                }
                else if (layer2_3Show == false && layer2_3TransShow == true)
                {
                    layer2_3Show = true;
                    layer2_3TransShow = false;
                }
                else if (layer2_3Show == true && layer2_3TransShow == false)
                {
                    layer2_3Show = false;
                    layer2_3TransShow = false;
                }
            }
            if (width - 400 + 13 * 24 < mouseState.X && mouseState.X < width - 400 + 14 * 24 && 24 * 7 < mouseState.Y && mouseState.Y < 24 * 8)
            {
                if (layer3_1Show == false && layer3_1TransShow == false)
                {
                    layer3_1TransShow = true;
                }
                else if (layer3_1Show == false && layer3_1TransShow == true)
                {
                    layer3_1Show = true;
                    layer3_1TransShow = false;
                }
                else if (layer3_1Show == true && layer3_1TransShow == false)
                {
                    layer3_1Show = false;
                    layer3_1TransShow = false;
                }
            }
            if (width - 400 + 14 * 24 < mouseState.X && mouseState.X < width - 400 + 15 * 24 && 24 * 7 < mouseState.Y && mouseState.Y < 24 * 8)
            {
                if (layer3_2Show == false && layer3_2TransShow == false)
                {
                    layer3_2TransShow = true;
                }
                else if (layer3_2Show == false && layer3_2TransShow == true)
                {
                    layer3_2Show = true;
                    layer3_2TransShow = false;
                }
                else if (layer3_2Show == true && layer3_2TransShow == false)
                {
                    layer3_2Show = false;
                    layer3_2TransShow = false;
                }
            }
            if (width - 400 + 15 * 24 < mouseState.X && mouseState.X < width - 400 + 16 * 24 && 24 * 7 < mouseState.Y && mouseState.Y < 24 * 8)
            {
                if (layer3_3Show == false && layer3_3TransShow == false)
                {
                    layer3_3TransShow = true;
                }
                else if (layer3_3Show == false && layer3_3TransShow == true)
                {
                    layer3_3Show = true;
                    layer3_3TransShow = false;
                }
                else if (layer3_3Show == true && layer3_3TransShow == false)
                {
                    layer3_3Show = false;
                    layer3_3TransShow = false;
                }
            }
            if (width - 400 + 13 * 24 < mouseState.X && mouseState.X < width - 400 + 14 * 24 && 24 * 9 < mouseState.Y && mouseState.Y < 24 * 10)
            {
                if (layer4_1Show == false && layer4_1TransShow == false)
                {
                    layer4_1TransShow = true;
                }
                else if (layer4_1Show == false && layer4_1TransShow == true)
                {
                    layer4_1Show = true;
                    layer4_1TransShow = false;
                }
                else if (layer4_1Show == true && layer4_1TransShow == false)
                {
                    layer4_1Show = false;
                    layer4_1TransShow = false;
                }
            }
            if (width - 400 + 14 * 24 < mouseState.X && mouseState.X < width - 400 + 15 * 24 && 24 * 9 < mouseState.Y && mouseState.Y < 24 * 10)
            {
                if (layer4_2Show == false && layer4_2TransShow == false)
                {
                    layer4_2TransShow = true;
                }
                else if (layer4_2Show == false && layer4_2TransShow == true)
                {
                    layer4_2Show = true;
                    layer4_2TransShow = false;
                }
                else if (layer4_2Show == true && layer4_2TransShow == false)
                {
                    layer4_2Show = false;
                    layer4_2TransShow = false;
                }
            }
            if (width - 400 + 15 * 24 < mouseState.X && mouseState.X < width - 400 + 16 * 24 && 24 * 9 < mouseState.Y && mouseState.Y < 24 * 10)
            {
                if (layerNpcShow)
                {
                    layerNpcShow = false;
                }
                else
                {
                    layerNpcShow = true;
                }
            }
            if (width - 400 + 14 * 24 < mouseState.X && mouseState.X < width - 400 + 15 * 24 && 24 * 11 < mouseState.Y && mouseState.Y < 24 * 12)
            {
                dePos.Clear();
                dePos.Add(new Point(-1, -1));
                usingDecoName = "none";
            }
            if (width - 400 + 14 * 24 < mouseState.X && mouseState.X < width - 400 + 15 * 24 && 24 * 19 < mouseState.Y && mouseState.Y < 24 * 20)
            {
                moveSpeed += 1;
            }
            if (width - 400 + 15 * 24 < mouseState.X && mouseState.X < width - 400 + 16 * 24 && 24 * 19 < mouseState.Y && mouseState.Y < 24 * 20)
            {
                moveSpeed -= 1;
            }
            for (int i = 0; i < 5; i++)
            {
                if (width - 400 + i * 2 * 24 < mouseState.X && mouseState.X < width - 400 + (i + 1) * 2 * 24 && 24 * 25 < mouseState.Y && mouseState.Y < 24 * 26)
                {
                    switch (i)
                    {
                        case 0:
                            decoUsingClassify = "Buildings_";
                            break;
                        case 1:
                            decoUsingClassify = "Decorats_";
                            break;
                        case 2:
                            decoUsingClassify = "Objects_";
                            break;
                        case 3:
                            decoUsingClassify = "Terrains_";
                            break;
                        case 4:
                            decoUsingClassify = "Others_";
                            break;
                        default:
                            break;
                    }
                    decoUsingNum = 1;
                    usingDecoName = decoUsingClassify + decoUsingNum;
                    decoratUsing = GetUsingDecoratsTexture(usingDecoName);
                    
                    dePos.Clear();
                    dePos.Add(new Point(-1, -1));
                }               
            }



            if (width - 400 + 10 * 24 < mouseState.X && mouseState.X < width - 400 + 11 * 24 && 24 * 25 < mouseState.Y && mouseState.Y < 24 * 26)
            {
                if (decoUsingNum == 1)
                {
                    switch (decoUsingClassify)
                    {
                        case "Buildings_":
                            decoUsingNum = buildingsNUM;
                            break;
                        case "Decorats_":
                            decoUsingNum = decoratsNUM;
                            break;
                        case "Objects_":
                            decoUsingNum = objectsNUM;
                            break;
                        case "Terrains_":
                            decoUsingNum = terrainsNUM;
                            break;
                        case "Others_":
                            decoUsingNum = othersNUM;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    decoUsingNum -= 1;
                }
                usingDecoName = decoUsingClassify + decoUsingNum;
                decoratUsing = GetUsingDecoratsTexture(usingDecoName);
                dePos.Clear();
                dePos.Add(new Point(-1, -1));
            }
            if (width - 400 + 11 * 24 < mouseState.X && mouseState.X < width - 400 + 12 * 24 && 24 * 25 < mouseState.Y && mouseState.Y < 24 * 26)
            {
                switch (decoUsingClassify)
                {
                    case "Buildings_":
                        if (decoUsingNum == buildingsNUM)
                        {
                            decoUsingNum = 1;
                        }
                        else
                        {
                            decoUsingNum += 1;
                        }
                        break;
                    case "Decorats_":
                        if (decoUsingNum == decoratsNUM)
                        {
                            decoUsingNum = 1;
                        }
                        else
                        {
                            decoUsingNum += 1;
                        }
                        break;
                    case "Objects_":
                        if (decoUsingNum == objectsNUM)
                        {
                            decoUsingNum = 1;
                        }
                        else
                        {
                            decoUsingNum += 1;
                        }
                        break;
                    case "Terrains_":
                        if (decoUsingNum == terrainsNUM)
                        {
                            decoUsingNum = 1;
                        }
                        else
                        {
                            decoUsingNum += 1;
                        }
                        break;
                    case "Others_":
                        if (decoUsingNum == othersNUM)
                        {
                            decoUsingNum = 1;
                        }
                        else
                        {
                            decoUsingNum += 1;
                        }
                        break;
                    default:
                        break;
                }
                usingDecoName = decoUsingClassify + decoUsingNum;
                decoratUsing = GetUsingDecoratsTexture(usingDecoName);
                dePos.Clear();
                dePos.Add(new Point(-1, -1));
            }
            if (width - 400 + 13 * 24 < mouseState.X && mouseState.X < width - 400 + 14 * 24 && 24 * 23 < mouseState.Y && mouseState.Y < 24 * 24)
            {
                showborder = false;
            }
            if (width - 400 + 15 * 24 < mouseState.X && mouseState.X < width - 400 + 16 * 24 && 24 * 23 < mouseState.Y && mouseState.Y < 24 * 24)
            {
                showborder = true;
            }
            if (width - 400 + 13 * 24 < mouseState.X && mouseState.X < width - 400 + 16 * 24 && 24 * 25 < mouseState.Y && mouseState.Y < 24 * 26)
            {
                Save();
                NpcPathSave();
            }
        }

        Texture2D GetUsingDecoratsTexture(string usingDecoratsName)
        {
            string classify = usingDecoratsName.Split('_')[0];
            int num = int.Parse(usingDecoratsName.Split('_')[1]);
            switch (classify)
            {
                case "Buildings":
                    for (int i = 1; i <= buildingsNUM; i++)
                    {
                        if (num == i)
                        {
                            if (i == 1)
                            {
                                return Buildings_1;
                            }
                            if (i == 2)
                            {
                                return Buildings_2;
                            }
                            if (i == 3)
                            {
                                return Buildings_3;
                            }
                            if (i == 4)
                            {
                                return Buildings_4;
                            }
                            if (i == 5)
                            {
                                return Buildings_5;
                            }
                            if (i == 6)
                            {
                                return Buildings_6;
                            }
                            if (i == 7)
                            {
                                return Buildings_7;
                            }
                            if (i == 8)
                            {
                                return Buildings_8;
                            }
                            if (i == 9)
                            {
                                return Buildings_9;
                            }
                            if (i == 10)
                            {
                                return Buildings_10;
                            }
                            if (i == 11)
                            {
                                return Buildings_11;
                            }
                            if (i == 12)
                            {
                                return Buildings_12;
                            }
                            if (i == 13)
                            {
                                return Buildings_13;
                            }
                            if (i == 14)
                            {
                                return Buildings_14;
                            }
                            if (i == 15)
                            {
                                return Buildings_15;
                            }
                            if (i == 16)
                            {
                                return Buildings_16;
                            }
                            if (i == 17)
                            {
                                return Buildings_17;
                            }
                            if (i == 18)
                            {
                                return Buildings_18;
                            }
                            if (i == 19)
                            {
                                return Buildings_19;
                            }
                            if (i == 20)
                            {
                                return Buildings_20;
                            }
                            if (i == 21)
                            {
                                return Buildings_21;
                            }
                            if (i == 22)
                            {
                                return Buildings_22;
                            }
                            if (i == 23)
                            {
                                return Buildings_23;
                            }
                        }
                    }
                    return null;
                case "Decorats":
                    for (int i = 1; i <= decoratsNUM; i++)
                    {
                        if (num == i)
                        {
                            if (i == 1)
                            {
                                return Decorats_1;
                            }
                            if (i == 2)
                            {
                                return Decorats_2;
                            }
                        }
                    }
                    return null;
                case "Objects":
                    for (int i = 1; i <= objectsNUM; i++)
                    {
                        if (num == i)
                        {
                            if (i == 1)
                            {
                                return Objects_1;
                            }
                        }
                    }
                    return null;
                case "Terrains":
                    for (int i = 1; i <= terrainsNUM; i++)
                    {
                        if (num == i)
                        {
                            if (i == 1)
                            {
                                return Terrains_1;
                            }
                            if (i == 2)
                            {
                                return Terrains_2;
                            }
                            if (i == 3)
                            {
                                return Terrains_3;
                            }
                            if (i == 4)
                            {
                                return Terrains_4;
                            }
                        }
                    }
                    return null;
                case "Others":
                    return null;
                default:
                    return null;
            }
        }

        void OperateTileAddition()
        {
            Vector2 truePos = new Vector2(camera.X + mouseState.X, camera.Y + mouseState.Y);
            foreach (Decorat item in maplist)
            {
                if (item.X * 24 * zoom < truePos.X && truePos.X < (item.X * 24 + 24) * zoom && item.Y * 24 * zoom < truePos.Y && truePos.Y < (item.Y * 24 + 24) * zoom)
                {
                    if (layerNpcShow)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y).IsCollide && maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).IsCollide = false;
                                }
                                else
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).IsCollide = true;
                                }
                               
                            }
                        }
                        else
                        {
                            if (item.IsCollide)
                            {
                                item.IsCollide = false;
                            }
                            else
                            {
                                item.IsCollide = true;
                            }

                        }


                        lastChange = item;
                    }
                    else if (layer4_2Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer4_2 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer4_2 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer4_2 = dePos[0];
                            item.Name_layer4_2 = usingDecoName;
                        }


                        lastChange = item;
                    }
                    else if (layer4_1Show)
                    {                      
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer4_1 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer4_1 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer4_1 = dePos[0];
                            item.Name_layer4_1 = usingDecoName;
                        }
                        

                        lastChange = item;
                    }
                    else if (layer3_3Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer3_3 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer3_3 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer3_3 = dePos[0];
                            item.Name_layer3_3 = usingDecoName;
                        }

                        lastChange = item;
                    }
                    else if (layer3_2Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer3_2 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer3_2 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer3_2 = dePos[0];
                            item.Name_layer3_2 = usingDecoName;
                        }

                        lastChange = item;
                    }
                    else if (layer3_1Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer3_1 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer3_1 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer3_1 = dePos[0];
                            item.Name_layer3_1 = usingDecoName;
                        }

                        lastChange = item;
                    }
                    else if (layer2_3Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer2_3 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer2_3 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer2_3 = dePos[0];
                            item.Name_layer2_3 = usingDecoName;
                        }

                        lastChange = item;
                    }
                    else if (layer2_2Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer2_2 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer2_2 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer2_2 = dePos[0];
                            item.Name_layer2_2 = usingDecoName;
                        }

                        lastChange = item;
                    }
                    else if (layer2_1Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {
                                int x = p.X - dePos[0].X;
                                int y = p.Y - dePos[0].Y;
                                Point it = new Point(item.X + x, item.Y + y);
                                if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                {
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer2_1 = p;
                                    maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer2_1 = usingDecoName;
                                }
                            }
                        }
                        else
                        {
                            item.DePos_layer2_1 = dePos[0];
                            item.Name_layer2_1 = usingDecoName;
                        }
                        
                        lastChange = item;
                    }
                    else if (layer1Show)
                    {
                        if (dePos.Count > 1)
                        {
                            foreach (Point p in dePos)
                            {

                                    int x = p.X - dePos[0].X;
                                    int y = p.Y - dePos[0].Y;
                                    Point it = new Point(item.X + x, item.Y + y);
                                    if (maplist.Find(u => u.X == it.X && u.Y == it.Y) != null)
                                    {
                                        maplist.Find(u => u.X == it.X && u.Y == it.Y).DePos_layer1 = p;
                                        maplist.Find(u => u.X == it.X && u.Y == it.Y).Name_layer1 = usingDecoName;
                                    }
                                
                            }
                        }
                        else
                        {
                            item.Name_layer1 = usingDecoName;
                            item.DePos_layer1 = dePos[0];
                        }
                        
                        lastChange = item;
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            //drawTime++;
            //spriteBatch.Draw(加载的图片,针对于屏幕来说开始画的位置，针对于图片来说剪裁的矩形位置和大小，图片渲染颜色（可做夜晚效果？），旋转，针对于图片的原点位置，缩放，渲染效果，层深度)
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(1, 1, 1));
            if (begin)
            {
                spriteBatch.Draw(bg, new Vector2(0, 0), new Rectangle(0, 0, 1024, 640), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
            }
            else
            {

                if (showBg)
                {
                    spriteBatch.Draw(bg, new Vector2(0, 0), new Rectangle(0, 0, 1024, 640), Color.White * colorPc, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);
                }

                ShowUI();
                ShowDecorats();
                ShowMouseHold();
                ShowMap();
                ShowFuncUsing();

                if (showAlert)
                {
                    spriteBatch.Draw(saveS, new Vector2(width / 2 - 96, 30), new Rectangle(0, 0, 192, 72), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);
                }
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        void ShowDecorats()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (decoratUsing == null)
                    {
                        spriteBatch.Draw(DecoratsNull, new Vector2(width - 398 + 24 * j, 24 * i), new Rectangle(j * 24, i * 24, 24, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
                    }
                    else
                    {
                        spriteBatch.Draw(decoratUsing, new Vector2(width - 398 + 24 * j, 24 * i), new Rectangle(j * 24, i * 24, 24, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
                    }

                }
            }
            spriteBatch.Draw(standdeco, new Vector2(width - 398, 0), new Rectangle(0,0, 12 * 24, 25 * 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.7f);
        }

        void ShowUI()
        {
            spriteBatch.Draw(mapBack, new Vector2(0, 0), camera, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.1f);

            spriteBatch.Draw(backright, new Vector2(width - 400, 0), new Rectangle(0, 0, 400, 1000), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.59f);
            spriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), new Rectangle(0, 0, 24, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.9f);

            if (!(width - 400 < mouseState.X && mouseState.X < width && 0 < mouseState.Y && mouseState.Y < height))
            {
                spriteBatch.DrawString(Fonts_UI6, ((int)((Mouse.GetState().X + camera.X) / 24f / zoom)).ToString() + "," + ((int)((Mouse.GetState().Y + camera.Y) / 24f / zoom)).ToString(), new Vector2(width - 400 + 14 * 24 - 25, 24 * 13), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            spriteBatch.DrawString(Fonts_UI6, mapSize.X + "," + mapSize.Y, new Vector2(width - 400 + 14 * 24 - 25, 24 * 15), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            spriteBatch.DrawString(Fonts_UI6, zoom.ToString(), new Vector2(width - 400 + 14 * 24 - 25, 24 * 17), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            spriteBatch.DrawString(Fonts_UI6, moveSpeed.ToString(), new Vector2(width - 400 + 14 * 24 - 25, 24 * 19), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            spriteBatch.DrawString(Fonts_UI6, usingDecoName, new Vector2(width - 400 + 14 * 24 - 40, 24 * 21), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
        }

        void ShowMouseHold()
        {
            if (dePos[0] != new Point(-1, -1))
            {
                if (dePos.Count == 1)
                {
                    spriteBatch.Draw(decoratUsing, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), new Rectangle(dePos[0].X * 24, dePos[0].Y * 24, 24, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.89f);
                }
                else
                {
                    foreach (Point p in dePos)
                    {
                        spriteBatch.Draw(decoratUsing, new Vector2(Mouse.GetState().X + (p.X - dePos[0].X) * 24, Mouse.GetState().Y + (p.Y - dePos[0].Y) * 24), new Rectangle(p.X * 24, p.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.89f);
                    }
                }
            }
            else
            {
                spriteBatch.Draw(tile, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), new Rectangle(0, 0, 24, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.89f);
            }
        }

        void ShowMap()
        {
            foreach (Decorat item in maplist)
            {
                if (item.X * 24 * zoom >= camera.X - 24 && camera.X + Window.ClientBounds.Width - 400 + 24 >= item.X * 24 * zoom && camera.Y - 24 <= item.Y * 24 * zoom && camera.Y + Window.ClientBounds.Height + 24 >= item.Y * 24 * zoom)
                {
                    bool showEmpty = true;
                    if (layerNpcShow)
                    {
                        if (item.IsCollide)
                        {
                            spriteBatch.Draw(collide, new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(0, 0, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.52f);
                        }
                    }
                    if (layer1Show)
                    {
                        if (item.DePos_layer1.X != -1 && item.DePos_layer1.Y != -1 && item.Name_layer1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer1.X * 24, item.DePos_layer1.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.2f);
                            showEmpty = false;
                        }
                    }
                    else if (layer1TransShow)
                    {
                        if (item.DePos_layer1.X != -1 && item.DePos_layer1.Y != -1 && item.Name_layer1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer1.X * 24, item.DePos_layer1.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.2f);
                            showEmpty = false;
                        }
                    }
                    if (layer2_1Show)
                    {
                        if (item.DePos_layer2_1.X != -1 && item.DePos_layer2_1.Y != -1 && item.Name_layer2_1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer2_1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer2_1.X * 24, item.DePos_layer2_1.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.3f);
                            showEmpty = false;
                        }
                    }
                    else if (layer2_1TransShow)
                    {
                        if (item.DePos_layer2_1.X != -1 && item.DePos_layer2_1.Y != -1 && item.Name_layer2_1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer2_1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer2_1.X * 24, item.DePos_layer2_1.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.3f);
                            showEmpty = false;
                        }
                    }
                    if (layer2_2Show)
                    {
                        if (item.DePos_layer2_2.X != -1 && item.DePos_layer2_2.Y != -1 && item.Name_layer2_2 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer2_2), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer2_2.X * 24, item.DePos_layer2_2.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.31f);
                            showEmpty = false;
                        }
                    }
                    else if (layer2_2TransShow)
                    {
                        if (item.DePos_layer2_2.X != -1 && item.DePos_layer2_2.Y != -1 && item.Name_layer2_2 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer2_2), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer2_2.X * 24, item.DePos_layer2_2.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.31f);
                            showEmpty = false;
                        }
                    }
                    if (layer2_3Show)
                    {
                        if (item.DePos_layer2_3.X != -1 && item.DePos_layer2_3.Y != -1 && item.Name_layer2_3 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer2_3), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer2_3.X * 24, item.DePos_layer2_3.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.4f);
                            showEmpty = false;
                        }
                    }
                    else if (layer2_3TransShow)
                    {
                        if (item.DePos_layer2_3.X != -1 && item.DePos_layer2_3.Y != -1 && item.Name_layer2_3 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer2_3), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer2_3.X * 24, item.DePos_layer2_3.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.4f);
                            showEmpty = false;
                        }
                    }
                    if (layer3_1Show)
                    {
                        if (item.DePos_layer3_1.X != -1 && item.DePos_layer3_1.Y != -1 && item.Name_layer3_1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer3_1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer3_1.X * 24, item.DePos_layer3_1.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.41f);
                            showEmpty = false;
                        }
                    }
                    else if (layer3_1TransShow)
                    {
                        if (item.DePos_layer3_1.X != -1 && item.DePos_layer3_1.Y != -1 && item.Name_layer3_1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer3_1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer3_1.X * 24, item.DePos_layer3_1.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.41f);
                            showEmpty = false;
                        }
                    }
                    if (layer3_2Show)
                    {
                        if (item.DePos_layer3_2.X != -1 && item.DePos_layer3_2.Y != -1 && item.Name_layer3_2 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer3_2), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer3_2.X * 24, item.DePos_layer3_2.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.42f);
                            showEmpty = false;
                        }
                    }
                    else if (layer3_2TransShow)
                    {
                        if (item.DePos_layer3_2.X != -1 && item.DePos_layer3_2.Y != -1 && item.Name_layer3_2 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer3_2), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer3_2.X * 24, item.DePos_layer3_2.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.42f);
                            showEmpty = false;
                        }
                    }
                    if (layer3_3Show)
                    {
                        if (item.DePos_layer3_3.X != -1 && item.DePos_layer3_3.Y != -1 && item.Name_layer3_3 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer3_3), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer3_3.X * 24, item.DePos_layer3_3.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.43f);
                            showEmpty = false;
                        }
                    }
                    else if (layer3_3TransShow)
                    {
                        if (item.DePos_layer3_3.X != -1 && item.DePos_layer3_3.Y != -1 && item.Name_layer3_3 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer3_3), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer3_3.X * 24, item.DePos_layer3_3.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.43f);
                            showEmpty = false;
                        }
                    }
                    if (layer4_1Show)
                    {
                        if (item.DePos_layer4_1.X != -1 && item.DePos_layer4_1.Y != -1 && item.Name_layer4_1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer4_1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer4_1.X * 24, item.DePos_layer4_1.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.5f);
                            showEmpty = false;
                        }
                    }
                    else if (layer4_1TransShow)
                    {
                        if (item.DePos_layer4_1.X != -1 && item.DePos_layer4_1.Y != -1 && item.Name_layer4_1 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer4_1), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer4_1.X * 24, item.DePos_layer4_1.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.5f);
                            showEmpty = false;
                        }
                    }
                    if (layer4_2Show)
                    {
                        if (item.DePos_layer4_2.X != -1 && item.DePos_layer4_2.Y != -1 && item.Name_layer4_2 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer4_2), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer4_2.X * 24, item.DePos_layer4_2.Y * 24, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.51f);
                            showEmpty = false;
                        }
                    }
                    else if (layer4_2TransShow)
                    {
                        if (item.DePos_layer4_2.X != -1 && item.DePos_layer4_2.Y != -1 && item.Name_layer4_2 != "none")
                        {
                            spriteBatch.Draw(GetUsingDecoratsTexture(item.Name_layer4_2), new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(item.DePos_layer4_2.X * 24, item.DePos_layer4_2.Y * 24, 24, 24), Color.White * 0.5f, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.51f);
                            showEmpty = false;
                        }
                    }
                    if (showEmpty)
                    {
                        spriteBatch.Draw(tile, new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(0, 0, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.15f);
                    }
                    if (showborder)
                    {
                        spriteBatch.Draw(tileborder, new Vector2(item.X * 24 * zoom - camera.X, item.Y * 24 * zoom - camera.Y), new Rectangle(0, 0, 24, 24), Color.White, 0, Vector2.Zero, zoom, SpriteEffects.None, 0.51f);
                    }

                }

            }
        }

        void ShowFuncUsing()
        {
            if (layer1Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 3), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer1TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 3), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer2_1Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 12 * 24, 24 * 5), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer2_1TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 12 * 24, 24 * 5), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer2_2Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 5), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer2_2TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 5), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer2_3Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 14 * 24, 24 * 5), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer2_3TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 14 * 24, 24 * 5), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer3_1Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 12 * 24, 24 * 7), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer3_1TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 12 * 24, 24 * 7), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer3_2Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 7), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer3_2TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 7), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer3_3Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 14 * 24, 24 * 7), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer3_3TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 14 * 24, 24 * 7), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer4_1Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 12 * 24, 24 * 9), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer4_1TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 12 * 24, 24 * 9), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layer4_2Show)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 9), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            else if (layer4_2TransShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 13 * 24, 24 * 9), new Rectangle(0, 0, 48, 24), Color.White * 0.5f, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);
            }
            if (layerNpcShow)
            {
                spriteBatch.Draw(selecting, new Vector2(width - 400 + 14 * 24, 24 * 9), new Rectangle(0, 0, 48, 24), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.6f);

            }
        }

        void Save()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);

            XmlNode root = xmlDoc.CreateElement("CV");
            xmlDoc.AppendChild(root);

            XmlNode nodeGlobal = xmlDoc.CreateNode(XmlNodeType.Element, "Tiles", null);
            foreach (Decorat item in maplist)
            {
                CreateNode(xmlDoc, nodeGlobal, "Tile", item.GetSave());
            }
            XmlNode objGlobal = xmlDoc.CreateNode(XmlNodeType.Element, "Objects", null);
            foreach (Decorat item in maplist)
            {
                switch (item.DePos_layer4_1.Y)
                {
                    case 0:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "PterocarpinTree", item.GetObj() + "|0");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "KiriTree", item.GetObj() + "|0");
                        }
                        if (item.DePos_layer4_1.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "PterocarpinTree", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_1.X == 8)
                        {
                            CreateNode(xmlDoc, objGlobal, "KiriTree", item.GetObj() + "|1");
                        }
                        break;
                    case 1:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|2");
                        }
                        if (item.DePos_layer4_1.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|3");
                        }
                        if (item.DePos_layer4_1.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|4");
                        }
                        if (item.DePos_layer4_1.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|5");
                        }
                        break;
                    case 2:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Flower", item.GetObj());
                        }
                        break;
                    case 3:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Decorats", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Decorats", item.GetObj() + "|2");
                        }
                        break;
                    case 4:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Barrier", item.GetObj());
                        }                       
                        break;
                    case 5:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Water", item.GetObj() + item.ProtectedData);
                        }
                        break;
                    case 6:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Trigger", item.ProtectedData);
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "NpcTrigger", item.GetObj() + item.ProtectedData);
                        }
                        if (item.DePos_layer4_1.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "NpcPosition", item.GetObj() + item.ProtectedData);
                        }
                        if (item.DePos_layer4_1.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "DoorTrigger", item.ProtectedData);
                        }    
                        break;
                    case 7:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|2");
                        }
                        if (item.DePos_layer4_1.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|3");
                        }
                        if (item.DePos_layer4_1.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|4");
                        }
                        if (item.DePos_layer4_1.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|5");
                        }
                        if (item.DePos_layer4_1.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|6");
                        }
                        if (item.DePos_layer4_1.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|7");
                        }
                        if (item.DePos_layer4_1.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|8");
                        }
                        if (item.DePos_layer4_1.X == 8)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|9");
                        }
                        if (item.DePos_layer4_1.X == 9)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|10");
                        }
                        break;
                    case 8:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Building", item.ProtectedData);
                        }
                        break;
                    case 9:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_1");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_1");
                        }
                        if (item.DePos_layer4_1.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_1");
                        }
                        if (item.DePos_layer4_1.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_2");
                        }
                        if (item.DePos_layer4_1.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_3");
                        }
                        if (item.DePos_layer4_1.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_4");
                        }
                        if (item.DePos_layer4_1.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_1");
                        }
                        if (item.DePos_layer4_1.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_3");
                        }
                        break;
                    case 10:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_2");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_2");
                        }
                        if (item.DePos_layer4_1.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_1");
                        }
                        if (item.DePos_layer4_1.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_2");
                        }
                        if (item.DePos_layer4_1.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_3");
                        }
                        if (item.DePos_layer4_1.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_4");
                        }
                        if (item.DePos_layer4_1.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_2");
                        }
                        if (item.DePos_layer4_1.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_4");
                        }
                        break;
                    case 11:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_3");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_3");
                        }
                        if (item.DePos_layer4_1.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_5");
                        }
                        if (item.DePos_layer4_1.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_6");
                        }
                        if (item.DePos_layer4_1.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_7");
                        }
                        if (item.DePos_layer4_1.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_8");
                        }
                        if (item.DePos_layer4_1.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Sand", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_1.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Sand", item.GetObj() + "|2");
                        }
                        break;
                    case 12:
                        if (item.DePos_layer4_1.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_4");
                        }
                        if (item.DePos_layer4_1.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_4");
                        }
                        break;
                    default:
                        break;
                }
                switch (item.DePos_layer4_2.Y)
                {
                    case 0:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "PterocarpinTree", item.GetObj() + "|0");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "KiriTree", item.GetObj() + "|0");
                        }
                        if (item.DePos_layer4_2.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "PterocarpinTree", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_2.X == 8)
                        {
                            CreateNode(xmlDoc, objGlobal, "KiriTree", item.GetObj() + "|1");
                        }
                        break;
                    case 1:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|2");
                        }
                        if (item.DePos_layer4_2.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|3");
                        }
                        if (item.DePos_layer4_2.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|4");
                        }
                        if (item.DePos_layer4_2.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Bush", item.GetObj() + "|5");
                        }
                        break;
                    case 2:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Flower", item.GetObj());
                        }
                        break;
                    case 3:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Decorats", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Decorats", item.GetObj() + "|2");
                        }
                        break;
                    case 4:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Barrier", item.GetObj());
                        }
                        break;
                    case 5:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Water", item.GetObj() + item.ProtectedData);
                        }
                        break;
                    case 6:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Trigger", item.ProtectedData);
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "NpcTrigger", item.GetObj() + item.ProtectedData);
                        }
                        if (item.DePos_layer4_2.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "NpcPosition", item.GetObj() + item.ProtectedData);
                        }
                        if (item.DePos_layer4_2.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "DoorTrigger", item.ProtectedData);
                        }   
                        break;
                    case 7:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|2");
                        }
                        if (item.DePos_layer4_2.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|3");
                        }
                        if (item.DePos_layer4_2.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|4");
                        }
                        if (item.DePos_layer4_2.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|5");
                        }
                        if (item.DePos_layer4_2.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|6");
                        }
                        if (item.DePos_layer4_2.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|7");
                        }
                        if (item.DePos_layer4_2.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|8");
                        }
                        if (item.DePos_layer4_2.X == 8)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|9");
                        }
                        if (item.DePos_layer4_2.X == 9)
                        {
                            CreateNode(xmlDoc, objGlobal, "Cliff", item.GetObj() + "|10");
                        }
                        break;
                    case 8:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Building", item.ProtectedData);
                        }
                        break;
                    case 9:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_1");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_1");
                        }
                        if (item.DePos_layer4_2.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_1");
                        }
                        if (item.DePos_layer4_2.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_2");
                        }
                        if (item.DePos_layer4_2.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_3");
                        }
                        if (item.DePos_layer4_2.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|1_4");
                        }
                        if (item.DePos_layer4_2.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_1");
                        }
                        if (item.DePos_layer4_2.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_3");
                        }
                        break;
                    case 10:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_2");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_2");
                        }
                        if (item.DePos_layer4_2.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_1");
                        }
                        if (item.DePos_layer4_2.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_2");
                        }
                        if (item.DePos_layer4_2.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_3");
                        }
                        if (item.DePos_layer4_2.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|2_4");
                        }
                        if (item.DePos_layer4_2.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_2");
                        }
                        if (item.DePos_layer4_2.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_4");
                        }
                        break;
                    case 11:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_3");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_3");
                        }
                        if (item.DePos_layer4_2.X == 2)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_5");
                        }
                        if (item.DePos_layer4_2.X == 3)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_6");
                        }
                        if (item.DePos_layer4_2.X == 4)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_7");
                        }
                        if (item.DePos_layer4_2.X == 5)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|5_8");
                        }
                        if (item.DePos_layer4_2.X == 6)
                        {
                            CreateNode(xmlDoc, objGlobal, "Sand", item.GetObj() + "|1");
                        }
                        if (item.DePos_layer4_2.X == 7)
                        {
                            CreateNode(xmlDoc, objGlobal, "Sand", item.GetObj() + "|2");
                        }
                        break;
                    case 12:
                        if (item.DePos_layer4_2.X == 0)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|3_4");
                        }
                        if (item.DePos_layer4_2.X == 1)
                        {
                            CreateNode(xmlDoc, objGlobal, "Wave", item.GetObj() + "|4_4");
                        }
                        break;
                    default:
                        break;
                }
            }
            root.AppendChild(nodeGlobal);
            root.AppendChild(objGlobal);
            try
            {

                if (Directory.Exists("./Content/Save") == false)
                {
                    Directory.CreateDirectory("./Content/Save");
                }
                xmlDoc.Save("./Content/Save/save.xml");
                showAlert = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        void NpcPathSave()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);

            XmlNode root = xmlDoc.CreateElement("CV");
            xmlDoc.AppendChild(root);

            XmlNode nodeGlobal = xmlDoc.CreateNode(XmlNodeType.Element, "Paths", null);
            foreach (Decorat item in maplist)
            {
                CreateNode(xmlDoc, nodeGlobal, "Path", item.GetNpcPathSave());
            }
            root.AppendChild(nodeGlobal);
            try
            {

                if (Directory.Exists("./Content/Save") == false)
                {
                    Directory.CreateDirectory("./Content/Save");
                }
                xmlDoc.Save("./Content/Save/Path.xml");
                showAlert = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        void Load()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"./Content/Save/save.xml");
            XmlNode root = xmlDoc.SelectSingleNode("CV");
            XmlNodeList rootList = root.ChildNodes;

            foreach (XmlNode rootNode in rootList)
            {
                if (rootNode.Name == "Tiles")
                {
                    XmlNodeList tiles = rootNode.ChildNodes;
                    foreach (XmlNode tile in tiles)
                    {
                        string context = tile.InnerText;
                        string[] inner = context.Split('|');
                        maplist.Add(new Decorat(int.Parse(inner[0]), int.Parse(inner[1]), inner[2], inner[4], inner[6], inner[8], inner[10], inner[12], inner[14], "none", "none", int.Parse(inner[3].Split(',')[0]), int.Parse(inner[3].Split(',')[1]), int.Parse(inner[5].Split(',')[0]), int.Parse(inner[5].Split(',')[1]), int.Parse(inner[7].Split(',')[0]), int.Parse(inner[7].Split(',')[1]), int.Parse(inner[9].Split(',')[0]), int.Parse(inner[9].Split(',')[1]), int.Parse(inner[11].Split(',')[0]), int.Parse(inner[11].Split(',')[1]), int.Parse(inner[13].Split(',')[0]), int.Parse(inner[13].Split(',')[1]), int.Parse(inner[15].Split(',')[0]), int.Parse(inner[15].Split(',')[1]), -1, -1, -1, -1, bool.Parse(inner[16])));//, bool.Parse(inner[12])
                        mapSize = new Point(int.Parse(inner[0]) + 1, int.Parse(inner[1]) + 1);
                    }
                }
                if (rootNode.Name == "Objects")
                {
                    XmlNodeList objs = rootNode.ChildNodes;
                    foreach (XmlNode obj in objs)
                    {
                        string context = obj.InnerText;
                        string[] inner = context.Split('|');
                        for (int i = 0; i < maplist.Count; i++)
                        {
                            if (maplist[i].X == int.Parse(inner[0]) && maplist[i].Y == int.Parse(inner[1]))
                            {
                                if (maplist[i].Name_layer4_1 == "none" && maplist[i].DePos_layer4_1 == new Point(-1, -1))
                                {
                                    maplist[i].Name_layer4_1 = "Objects_1";
                                    switch (obj.Name)
                                    {
                                        case "PterocarpinTree":
                                            maplist[i].DePos_layer4_1 = new Point(0, 0);
                                            break;
                                        case "KiriTree":
                                            if (inner[2] == "0")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 0);
                                            }
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(8, 0);
                                            }
                                            break;
                                        case "Bush":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(0, 1);
                                            }
                                            if (inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 1);
                                            }
                                            if (inner[2] == "3")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(2, 1);
                                            }
                                            if (inner[2] == "4")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(3, 1);
                                            }
                                            if (inner[2] == "5")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(4, 1);
                                            }
                                            break;
                                        case "Flower":
                                            maplist[i].DePos_layer4_1 = new Point(0, 2);
                                            break;
                                        case "Decorats":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(0, 3);
                                            }
                                            if (inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 3);
                                            }
                                            break;
                                        case "Barrier":
                                            maplist[i].DePos_layer4_1 = new Point(0, 4);
                                            break;
                                        case "Water":
                                            maplist[i].DePos_layer4_1 = new Point(0, 5);
                                            maplist[i].ProtectedData = "|" + inner[2];
                                            break;
                                        case "Trigger":
                                            maplist[i].DePos_layer4_1 = new Point(0, 6);
                                            maplist[i].ProtectedData = context;
                                            break;
                                        case "DoorTrigger":
                                            maplist[i].DePos_layer4_1 = new Point(3, 6);
                                            maplist[i].ProtectedData = context;
                                            break;
                                        case "NpcTrigger":
                                            maplist[i].DePos_layer4_1 = new Point(1, 6);
                                            maplist[i].ProtectedData = "|" + inner[2] + "|" + inner[3] + "|" + inner[4];
                                            break;
                                        case "NpcPosition":
                                            maplist[i].DePos_layer4_1 = new Point(2, 6);
                                            maplist[i].ProtectedData = "|" + inner[2];
                                            break;
                                        case "Cliff":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(0, 7);
                                            }
                                            if (inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 7);
                                            }
                                            if (inner[2] == "3")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(2, 7);
                                            }
                                            if (inner[2] == "4")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(3, 7);
                                            }
                                            if (inner[2] == "5")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(4, 7);
                                            }
                                            if (inner[2] == "6")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(5, 7);
                                            }
                                            if (inner[2] == "7")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(6, 7);
                                            }
                                            if (inner[2] == "8")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(7, 7);
                                            }
                                            if (inner[2] == "9")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(8, 7);
                                            }
                                            if (inner[2] == "10")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(9, 7);
                                            }
                                            break;
                                        case "Building":
                                            maplist[i].DePos_layer4_1 = new Point(0, 8);
                                            maplist[i].ProtectedData = context;
                                            break;
                                        case "Wave":
                                            if (inner[2] == "1_1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(2, 9);
                                            }
                                            if (inner[2] == "1_2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(3, 9);
                                            }
                                            if (inner[2] == "1_3")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(4, 9);
                                            }
                                            if (inner[2] == "1_4")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(5, 9);
                                            }
                                            if (inner[2] == "2_1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(2, 10);
                                            }
                                            if (inner[2] == "2_2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(3, 10);
                                            }
                                            if (inner[2] == "2_3")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(4, 10);
                                            }
                                            if (inner[2] == "2_4")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(5, 10);
                                            }
                                            if (inner[2] == "3_1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(0, 9);
                                            }
                                            if (inner[2] == "3_2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(0, 10);
                                            }
                                            if (inner[2] == "3_3")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(0, 11);
                                            }
                                            if (inner[2] == "3_4")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(0, 12);
                                            }
                                            if (inner[2] == "4_1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 9);
                                            }
                                            if (inner[2] == "4_2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 10);
                                            }
                                            if (inner[2] == "4_3")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 11);
                                            }
                                            if (inner[2] == "4_4")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(1, 12);
                                            }
                                            if (inner[2] == "5_1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(6, 9);
                                            }
                                            if (inner[2] == "5_2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(6, 10);
                                            }
                                            if (inner[2] == "5_3")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(7, 9);
                                            }
                                            if (inner[2] == "5_4")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(7, 10);
                                            }
                                            if (inner[2] == "5_5")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(2, 11);
                                            }
                                            if (inner[2] == "5_6")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(3, 11);
                                            }
                                            if (inner[2] == "5_7")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(4, 11);
                                            }
                                            if (inner[2] == "5_8")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(5, 11);
                                            }
                                            break;
                                        case "Sand":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(6, 11);
                                            }
                                            else if(inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_1 = new Point(7, 11);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    maplist[i].Name_layer4_2 = "Objects_1";
                                    switch (obj.Name)
                                    {
                                        case "PterocarpinTree":
                                            maplist[i].DePos_layer4_2 = new Point(0, 0);
                                            break;
                                        case "KiriTree":
                                            if (inner[2] == "0")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 0);
                                            }
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(8, 0);
                                            }
                                            break;
                                        case "Bush":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(0, 1);
                                            }
                                            if (inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 1);
                                            }
                                            if (inner[2] == "3")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(2, 1);
                                            }
                                            if (inner[2] == "4")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(3, 1);
                                            }
                                            if (inner[2] == "5")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(4, 1);
                                            }
                                            break;
                                        case "Flower":
                                            maplist[i].DePos_layer4_2 = new Point(0, 2);
                                            break;
                                        case "Decorats":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(0, 3);
                                            }
                                            if (inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 3);
                                            }
                                            break;
                                        case "Barrier":
                                            maplist[i].DePos_layer4_2 = new Point(0, 4);
                                            break;
                                        case "Water":
                                            maplist[i].DePos_layer4_2 = new Point(0, 5);
                                            maplist[i].ProtectedData = "|" + inner[2];
                                            break;
                                        case "Trigger":
                                            maplist[i].DePos_layer4_2 = new Point(0, 6);
                                            maplist[i].ProtectedData = context;
                                            break;
                                        case "DoorTrigger":
                                            maplist[i].DePos_layer4_2 = new Point(3, 6);
                                            maplist[i].ProtectedData = context;
                                            break;
                                        case "NpcTrigger":
                                            maplist[i].DePos_layer4_2 = new Point(1, 6);
                                            maplist[i].ProtectedData = "|" + inner[2] + "|" + inner[3] + "|" + inner[4];
                                            break;
                                        case "NpcPosition":
                                            maplist[i].DePos_layer4_2 = new Point(2, 6);
                                            maplist[i].ProtectedData = "|" + inner[2];
                                            break;
                                        case "Cliff":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(0, 7);
                                            }
                                            if (inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 7);
                                            }
                                            if (inner[2] == "3")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(2, 7);
                                            }
                                            if (inner[2] == "4")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(3, 7);
                                            }
                                            if (inner[2] == "5")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(4, 7);
                                            }
                                            if (inner[2] == "6")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(5, 7);
                                            }
                                            if (inner[2] == "7")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(6, 7);
                                            }
                                            if (inner[2] == "8")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(7, 7);
                                            }
                                            if (inner[2] == "9")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(8, 7);
                                            }
                                            if (inner[2] == "10")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(9, 7);
                                            }
                                            break;
                                        case "Building":
                                            maplist[i].DePos_layer4_2 = new Point(0, 8);
                                            maplist[i].ProtectedData = context;
                                            break;
                                        case "Wave":
                                            if (inner[2] == "1_1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(2, 9);
                                            }
                                            if (inner[2] == "1_2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(3, 9);
                                            }
                                            if (inner[2] == "1_3")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(4, 9);
                                            }
                                            if (inner[2] == "1_4")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(5, 9);
                                            }
                                            if (inner[2] == "2_1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(2, 10);
                                            }
                                            if (inner[2] == "2_2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(3, 10);
                                            }
                                            if (inner[2] == "2_3")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(4, 10);
                                            }
                                            if (inner[2] == "2_4")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(5, 10);
                                            }
                                            if (inner[2] == "3_1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(0, 9);
                                            }
                                            if (inner[2] == "3_2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(0, 10);
                                            }
                                            if (inner[2] == "3_3")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(0, 11);
                                            }
                                            if (inner[2] == "3_4")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(0, 12);
                                            }
                                            if (inner[2] == "4_1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 9);
                                            }
                                            if (inner[2] == "4_2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 10);
                                            }
                                            if (inner[2] == "4_3")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 11);
                                            }
                                            if (inner[2] == "4_4")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(1, 12);
                                            }
                                            if (inner[2] == "5_1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(6, 9);
                                            }
                                            if (inner[2] == "5_2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(6, 10);
                                            }
                                            if (inner[2] == "5_3")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(7, 9);
                                            }
                                            if (inner[2] == "5_4")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(7, 10);
                                            }
                                            if (inner[2] == "5_5")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(2, 11);
                                            }
                                            if (inner[2] == "5_6")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(3, 11);
                                            }
                                            if (inner[2] == "5_7")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(4, 11);
                                            }
                                            if (inner[2] == "5_8")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(5, 11);
                                            }
                                            break;
                                        case "Sand":
                                            if (inner[2] == "1")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(6, 11);
                                            }
                                            else if (inner[2] == "2")
                                            {
                                                maplist[i].DePos_layer4_2 = new Point(7, 11);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }  
    }
}
