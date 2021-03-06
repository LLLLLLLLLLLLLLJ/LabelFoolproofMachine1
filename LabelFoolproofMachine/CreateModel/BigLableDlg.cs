﻿using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabelFoolproofMachine.Halcon;
using ConfigManager;

namespace LabelFoolproofMachine
{
    public partial class BigLableDlg : Form
    {
        public BigLableDlg()
        {
            InitializeComponent();
        }

        public HalconDotNet.HTuple WindowsHandle = new HalconDotNet.HTuple();
        public static HObject HRegion = new HObject();

        private void BigLableDlg_Load(object sender, EventArgs e)
        {
            HOperatorSet.OpenWindow(0, 0, pictureBox1.Width, pictureBox1.Height, pictureBox1.Handle, "visible", "", out WindowsHandle);
            HalconCommonFunc.SetPart(WindowsHandle, 1920, 1200, pictureBox1.Width, pictureBox1.Height);
            HalconCommonFunc.DisplayImage(PublicData.createNewCheckModel.ModelImage, WindowsHandle);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (DrawRegionCheck() == 1)
            {
                PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleRegion1 = HRegion;
                HalconCommonFunc.BigLableblob(PublicData.createNewCheckModel.ModelImage,
                    PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleRegion1,
                    out HTuple BigLableAngleNumber1, out PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleSelected1);
                HalconCommonFunc.DisplayRegionOrXld(PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleSelected1, "blue", WindowsHandle, 2);
                PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleNumber1 = BigLableAngleNumber1.D;
            }
        }
        public int DrawRegionCheck()
        {
            pictureBox1.Focus();
            if (PublicData.GetImage == false)
            {
                MessageBox.Show("未获取到图片");
                return 0;
            }
            else
            {

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        HalconCommonFunc.DrawRegion(WindowsHandle, DrawModel.Rectangle1, out HRegion);
                        break;
                    case 1:
                        HalconCommonFunc.DrawRegion(WindowsHandle, DrawModel.Rectangle2, out HRegion);
                        break;
                    case 2:
                        HalconCommonFunc.DrawRegion(WindowsHandle, DrawModel.Circle, out HRegion);
                        break;

                }
                return 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (DrawRegionCheck() == 1)
            {
                PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleRegion2 = HRegion;
                HalconCommonFunc.BigLableblob(PublicData.createNewCheckModel.ModelImage,
                    PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleRegion2,
                    out HTuple BigLableAngleNumber2, out PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleSelected2);
                HalconCommonFunc.DisplayRegionOrXld(PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleSelected2, "blue", WindowsHandle, 2);
                PublicData.createNewCheckModel.checkBigLableModel.BigLableAngleNumber2 = BigLableAngleNumber2.D;
            } 
           
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (DrawRegionCheck() == 1)
            {
                PublicData.createNewCheckModel.checkBigLableModel.BigLableRegion = HRegion;
                HalconCommonFunc.BigLablIntervalLable(PublicData.createNewCheckModel.ModelImage,
                     PublicData.createNewCheckModel.checkBigLableModel.BigLableRegion,
                    out HTuple BigLableNumber, out PublicData.createNewCheckModel.checkBigLableModel.BigLableSelect);
                HalconCommonFunc.DisplayRegionOrXld(PublicData.createNewCheckModel.checkBigLableModel.BigLableSelect, "blue", WindowsHandle, 2);
                PublicData.createNewCheckModel.checkBigLableModel.BigLableNumber = BigLableNumber.D;
            }
            
           
        }

        private void BigLableDlg_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                HalconCommonFunc.DisplayImage(PublicData.createNewCheckModel.ModelImage, WindowsHandle);
            }
        }
    }
}
