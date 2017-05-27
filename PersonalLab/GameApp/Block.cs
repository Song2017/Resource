using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ChinaBlock
{
    class Block
    {
        public Square sq1;  //组成block的四个小方块
        public Square sq2;
        public Square sq3;
        public Square sq4;

        private const int squareSize = GameField.SquareSize; //小方块的边长
        public enum BlockTypes
        {
            undefined = 0,
            O = 1,
            I = 2,
            J = 3,
            L = 4,
            T = 5,
            Z = 6,
            S = 7
        };//一共有7种形状
        public BlockTypes blockType;  //方块的形状
        //七个小方块的颜色数组
        private Color foreColor;
        private Color backColor;
        //方块的方向
        public enum RotateDirections
        {
            North = 1,
            East = 2,
            South = 3,
            West = 4
        };
        public RotateDirections myRotation = RotateDirections.North;

        public Block(Point thisLocation, BlockTypes bType)
        { //当blockType为undefined时，随机产生方块形状
            Random rand = new Random();
            if (bType == BlockTypes.undefined)
            {
                blockType = (BlockTypes)(rand.Next(7) + 1);
            }
            else
                blockType = bType;
            //设置四小方块的颜色
            int i = (int)blockType - 1;
            foreColor = GameField.BlockForeColor[i];
            backColor = GameField.BlockBackColor[i];
            Size squareS = new Size(squareSize, squareSize);
            sq1 = new Square(squareS, foreColor, backColor);
            sq2 = new Square(squareS, foreColor, backColor);
            sq3 = new Square(squareS, foreColor, backColor);
            sq4 = new Square(squareS, foreColor, backColor);

            //设置小方块的位置，组合成指定形状的一个大方块
            switch (blockType)
            {
                case BlockTypes.O:
                    //组合成正方形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X, thisLocation.Y + squareSize);
                    sq4.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    break;
                case BlockTypes.I:
                    //组合成线形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y);
                    sq4.loct = new Point(thisLocation.X + 3 * squareSize, thisLocation.Y);
                    break;
                case BlockTypes.J:
                    //组合成J形
                    sq1.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    sq3.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + 2 * squareSize);
                    sq4.loct = new Point(thisLocation.X, thisLocation.Y + 2 * squareSize);
                    break;
                case BlockTypes.L:
                    //组合成l形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X, thisLocation.Y + squareSize);
                    sq3.loct = new Point(thisLocation.X, thisLocation.Y + 2 * squareSize);
                    sq4.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + 2 * squareSize);
                    break;
                case BlockTypes.T:
                    //组合成T形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y);
                    sq4.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    break;
                case BlockTypes.Z:
                    //组合成z形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    sq4.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y + squareSize);
                    break;
                case BlockTypes.S:
                    //组合成S形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y + squareSize);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    sq3.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq4.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y);
                    break;
            }
        }
        //含有自定义颜色的重载
        public Block(Point thisLocation, BlockTypes bType, Color fc, Color bc)
        { //当blockType为undefined时，随机产生方块形状
            Random rand = new Random();

            if (bType == BlockTypes.undefined)
            {
                blockType = (BlockTypes)(rand.Next(7) + 1);
            }
            else
                blockType = bType;
            //设置四小方块的颜色
            Size squareS = new Size(squareSize, squareSize);
            sq1 = new Square(squareS, fc, bc);
            sq2 = new Square(squareS, fc, bc);
            sq3 = new Square(squareS, fc, bc);
            sq4 = new Square(squareS, fc, bc);

            //设置小方块的位置，组合成指定形状的一个大方块
            switch (blockType)
            {
                case BlockTypes.O:
                    //组合成正方形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X, thisLocation.Y + squareSize);
                    sq4.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    break;
                case BlockTypes.I:
                    //组合成线形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y);
                    sq4.loct = new Point(thisLocation.X + 3 * squareSize, thisLocation.Y);
                    break;
                case BlockTypes.J:
                    //组合成J形
                    sq1.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    sq3.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + 2 * squareSize);
                    sq4.loct = new Point(thisLocation.X, thisLocation.Y + 2 * squareSize);
                    break;
                case BlockTypes.L:
                    //组合成l形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X, thisLocation.Y + squareSize);
                    sq3.loct = new Point(thisLocation.X, thisLocation.Y + 2 * squareSize);
                    sq4.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + 2 * squareSize);
                    break;
                case BlockTypes.T:
                    //组合成T形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y);
                    sq4.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    break;
                case BlockTypes.Z:
                    //组合成z形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq3.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    sq4.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y + squareSize);
                    break;
                case BlockTypes.S:
                    //组合成S形
                    sq1.loct = new Point(thisLocation.X, thisLocation.Y + squareSize);
                    sq2.loct = new Point(thisLocation.X + squareSize, thisLocation.Y + squareSize);
                    sq3.loct = new Point(thisLocation.X + squareSize, thisLocation.Y);
                    sq4.loct = new Point(thisLocation.X + 2 * squareSize, thisLocation.Y);
                    break;
            }
        }

        /*画方块*/
        public void Draw(System.IntPtr winHandle)
        {
            sq1.Draw(winHandle);
            sq2.Draw(winHandle);
            sq3.Draw(winHandle);
            sq4.Draw(winHandle);
        }
        /*擦方块*/
        public void Erase(System.IntPtr winHandle)
        {
            sq1.Erase(winHandle);
            sq2.Erase(winHandle);
            sq3.Erase(winHandle);
            sq4.Erase(winHandle);
        }

        /*移动*/
        public bool down()
        {
            //检测是否可以下移
            if (GameField.isEmpty(sq1.loct.X / squareSize, sq1.loct.Y / squareSize + 1) &&
                GameField.isEmpty(sq2.loct.X / squareSize, sq2.loct.Y / squareSize + 1) &&
                GameField.isEmpty(sq3.loct.X / squareSize, sq3.loct.Y / squareSize + 1) &&
                GameField.isEmpty(sq4.loct.X / squareSize, sq4.loct.Y / squareSize + 1))
            {
                Erase(GameField.winHandle);
                sq1.loct = new Point(sq1.loct.X, sq1.loct.Y + squareSize);
                sq2.loct = new Point(sq2.loct.X, sq2.loct.Y + squareSize);
                sq3.loct = new Point(sq3.loct.X, sq3.loct.Y + squareSize);
                sq4.loct = new Point(sq4.loct.X, sq4.loct.Y + squareSize);
                Draw(GameField.winHandle);
                return true;
            }
            else  //如果不能下移了
            {
                GameField.stopSquare(sq1, sq1.loct.X / squareSize, sq1.loct.Y / squareSize);
                GameField.stopSquare(sq2, sq2.loct.X / squareSize, sq2.loct.Y / squareSize);
                GameField.stopSquare(sq3, sq3.loct.X / squareSize, sq3.loct.Y / squareSize);
                GameField.stopSquare(sq4, sq4.loct.X / squareSize, sq4.loct.Y / squareSize);
                return false; //表示可以弹出下一个block了
            }
        }
        public bool left()
        {
            //检测是否可以左移
            if (GameField.isEmpty(sq1.loct.X / squareSize - 1, sq1.loct.Y / squareSize) &&
                GameField.isEmpty(sq2.loct.X / squareSize - 1, sq2.loct.Y / squareSize) &&
                GameField.isEmpty(sq3.loct.X / squareSize - 1, sq3.loct.Y / squareSize) &&
                GameField.isEmpty(sq4.loct.X / squareSize - 1, sq4.loct.Y / squareSize))
            {
                Erase(GameField.winHandle);
                sq1.loct = new Point(sq1.loct.X - squareSize, sq1.loct.Y);
                sq2.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y);
                sq3.loct = new Point(sq3.loct.X - squareSize, sq3.loct.Y);
                sq4.loct = new Point(sq4.loct.X - squareSize, sq4.loct.Y);
                Draw(GameField.winHandle);
                return true;
            }
            else  //如果不能左移了
            {
                return false;
            }
        }
        public bool right()
        {
            //检测是否可以右移
            if (GameField.isEmpty(sq1.loct.X / squareSize + 1, sq1.loct.Y / squareSize) &&
                GameField.isEmpty(sq2.loct.X / squareSize + 1, sq2.loct.Y / squareSize) &&
                GameField.isEmpty(sq3.loct.X / squareSize + 1, sq3.loct.Y / squareSize) &&
                GameField.isEmpty(sq4.loct.X / squareSize + 1, sq4.loct.Y / squareSize))
            {
                Erase(GameField.winHandle);
                sq1.loct = new Point(sq1.loct.X + squareSize, sq1.loct.Y);
                sq2.loct = new Point(sq2.loct.X + squareSize, sq2.loct.Y);
                sq3.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y);
                sq4.loct = new Point(sq4.loct.X + squareSize, sq4.loct.Y);
                Draw(GameField.winHandle);
                return true;
            }
            else  //如果不能右移了
            {
                return false;
            }
        }
        /*旋转block*/
        public void Rotate()
        {
            //保存每个小块的位置
            Point oldPosition1 = sq1.loct;
            Point oldPosition2 = sq2.loct;
            Point oldPosition3 = sq3.loct;
            Point oldPosition4 = sq4.loct;
            //保存当前的方向
            RotateDirections oldRotation = myRotation;
            //开始试着旋转方块，旋转方向：顺时针方向 旋转中心点为形状拐点
            Erase(GameField.winHandle);
            switch (blockType)
            {
                case BlockTypes.O:
                    break;
                case BlockTypes.I:
                    //直线的旋转只有两种方向
                    switch (myRotation)
                    {
                        case RotateDirections.North:
                            myRotation = RotateDirections.East;
                            sq1.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y);
                            sq3.loct = new Point(sq2.loct.X + squareSize, sq2.loct.Y);
                            sq4.loct = new Point(sq2.loct.X + 2 * squareSize, sq2.loct.Y);
                            break;
                        case RotateDirections.East:
                            myRotation = RotateDirections.North;
                            sq1.loct = new Point(sq2.loct.X, sq2.loct.Y - squareSize);
                            sq3.loct = new Point(sq2.loct.X, sq2.loct.Y + squareSize);
                            sq4.loct = new Point(sq2.loct.X, sq2.loct.Y + 2 * squareSize);
                            break;
                    }
                    break;
                case BlockTypes.J:
                    //J形方块有四种旋转方向
                    switch (myRotation)
                    {
                        case RotateDirections.North:
                            myRotation = RotateDirections.East;
                            sq1.loct = new Point(sq3.loct.X + 2 * squareSize, sq3.loct.Y);
                            sq2.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y);
                            sq4.loct = new Point(sq3.loct.X, sq3.loct.Y - squareSize);
                            break;
                        case RotateDirections.East:
                            myRotation = RotateDirections.South;
                            sq1.loct = new Point(sq3.loct.X, sq3.loct.Y + 2 * squareSize);
                            sq2.loct = new Point(sq3.loct.X, sq3.loct.Y + squareSize);
                            sq4.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y);
                            break;
                        case RotateDirections.South:
                            myRotation = RotateDirections.West;
                            sq1.loct = new Point(sq3.loct.X - 2 * squareSize, sq3.loct.Y);
                            sq2.loct = new Point(sq3.loct.X - squareSize, sq3.loct.Y);
                            sq4.loct = new Point(sq3.loct.X, sq3.loct.Y + squareSize);
                            break;
                        case RotateDirections.West:
                            myRotation = RotateDirections.North;
                            sq1.loct = new Point(sq3.loct.X, sq3.loct.Y - 2 * squareSize);
                            sq2.loct = new Point(sq3.loct.X, sq3.loct.Y - squareSize);
                            sq4.loct = new Point(sq3.loct.X - squareSize, sq3.loct.Y);
                            break;
                    }
                    break;
                case BlockTypes.L:
                    //L形方块有四种旋转方向
                    switch (myRotation)
                    {
                        case RotateDirections.North:
                            myRotation = RotateDirections.East;
                            sq1.loct = new Point(sq3.loct.X + 2 * squareSize, sq3.loct.Y);
                            sq2.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y);
                            sq4.loct = new Point(sq3.loct.X, sq3.loct.Y + squareSize);
                            break;
                        case RotateDirections.East:
                            myRotation = RotateDirections.South;
                            sq1.loct = new Point(sq3.loct.X, sq3.loct.Y + 2 * squareSize);
                            sq2.loct = new Point(sq3.loct.X, sq3.loct.Y + squareSize);
                            sq4.loct = new Point(sq3.loct.X - squareSize, sq3.loct.Y);
                            break;
                        case RotateDirections.South:
                            myRotation = RotateDirections.West;
                            sq1.loct = new Point(sq3.loct.X - 2 * squareSize, sq3.loct.Y);
                            sq2.loct = new Point(sq3.loct.X - squareSize, sq3.loct.Y);
                            sq4.loct = new Point(sq3.loct.X, sq3.loct.Y - squareSize);
                            break;
                        case RotateDirections.West:
                            myRotation = RotateDirections.North;
                            sq1.loct = new Point(sq3.loct.X, sq3.loct.Y - 2 * squareSize);
                            sq2.loct = new Point(sq3.loct.X, sq3.loct.Y - squareSize);
                            sq4.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y);
                            break;
                    }
                    break;
                case BlockTypes.T:
                    //T形方块也有四种旋转方向
                    switch (myRotation)
                    {
                        case RotateDirections.North:
                            myRotation = RotateDirections.East;
                            sq1.loct = new Point(sq2.loct.X, sq2.loct.Y - squareSize);
                            sq3.loct = new Point(sq2.loct.X, sq2.loct.Y + squareSize);
                            sq4.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y);
                            break;
                        case RotateDirections.East:
                            myRotation = RotateDirections.South;
                            sq1.loct = new Point(sq2.loct.X + squareSize, sq2.loct.Y);
                            sq3.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y);
                            sq4.loct = new Point(sq2.loct.X, sq2.loct.Y - squareSize);
                            break;
                        case RotateDirections.South:
                            myRotation = RotateDirections.West;
                            sq1.loct = new Point(sq2.loct.X, sq2.loct.Y + squareSize);
                            sq3.loct = new Point(sq2.loct.X, sq2.loct.Y - squareSize);
                            sq4.loct = new Point(sq2.loct.X + squareSize, sq2.loct.Y);
                            break;
                        case RotateDirections.West:
                            myRotation = RotateDirections.North;
                            sq1.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y);
                            sq3.loct = new Point(sq2.loct.X + squareSize, sq2.loct.Y);
                            sq4.loct = new Point(sq2.loct.X, sq2.loct.Y + squareSize);
                            break;
                    }
                    break;
                case BlockTypes.Z:
                    //Z形方块有两种旋转方向
                    switch (myRotation)
                    {
                        case RotateDirections.North:
                            myRotation = RotateDirections.East;
                            sq1.loct = new Point(sq2.loct.X, sq2.loct.Y - squareSize);
                            sq3.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y);
                            sq4.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y + squareSize);
                            break;
                        case RotateDirections.East:
                            myRotation = RotateDirections.North;
                            sq1.loct = new Point(sq2.loct.X - squareSize, sq2.loct.Y);
                            sq3.loct = new Point(sq2.loct.X, sq2.loct.Y + squareSize);
                            sq4.loct = new Point(sq2.loct.X + squareSize, sq2.loct.Y + squareSize);
                            break;
                    }
                    break;
                case BlockTypes.S:
                    //S形方块有两种旋转方向
                    switch (myRotation)
                    {
                        case RotateDirections.North:
                            myRotation = RotateDirections.East;
                            sq1.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y + squareSize);
                            sq2.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y);
                            sq4.loct = new Point(sq3.loct.X, sq3.loct.Y - squareSize);
                            break;
                        case RotateDirections.East:
                            myRotation = RotateDirections.North;
                            sq1.loct = new Point(sq3.loct.X - squareSize, sq3.loct.Y + squareSize);
                            sq2.loct = new Point(sq3.loct.X, sq3.loct.Y + squareSize);
                            sq4.loct = new Point(sq3.loct.X + squareSize, sq3.loct.Y);
                            break;
                    }
                    break;
            }
            //旋转之后检测位置是否冲突
            if (!(GameField.isEmpty(sq1.loct.X / squareSize, sq1.loct.Y / squareSize) &&
                GameField.isEmpty(sq2.loct.X / squareSize, sq2.loct.Y / squareSize) &&
                GameField.isEmpty(sq3.loct.X / squareSize, sq3.loct.Y / squareSize) &&
                GameField.isEmpty(sq4.loct.X / squareSize, sq4.loct.Y / squareSize)))
            {//如果有冲突则回到原来的状态
                myRotation = oldRotation;
                sq1.loct = oldPosition1;
                sq2.loct = oldPosition2;
                sq3.loct = oldPosition3;
                sq4.loct = oldPosition4;
            }
            Draw(GameField.winHandle);
        }
        /*检测是否到顶*/
        public int Top()
        {
            return Math.Min(sq1.loct.Y, Math.Min(sq2.loct.Y, Math.Min(sq3.loct.Y, sq4.loct.Y)));
        }
    }
}
