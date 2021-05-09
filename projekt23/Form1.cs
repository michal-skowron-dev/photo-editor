using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace projekt19
{
    public partial class Form1 : Form
    {
        Bitmap obraz1, obraz2;
        int wysokosc = 0, szerokosc = 0,
            podzial1 = 0, podzial2 = 0,
            R = 0, G = 0, B = 0, S = 0,
            x1 = 0, x2 = 0, y1 = 0, y2 = 0,
            opcja = 0, wartosc = 0;
        bool esc = true, zrodlo = true, filtracja = false;
        int postep = 0;

        public void CzyscTextBoxy()
        {
            if (label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();
            }
            if (label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();
            }
            if (label7.ForeColor == Color.DarkGreen)
            {
                UstawKolor7();
            }
            for (int i = 1; i <= 49; i++)
            {
                foreach (Control c in tabPage2.Controls)
                {
                    if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                    {
                        c.Text = "";
                    }
                }
            }
        }

        public void ZablokujElementy()
        {
            CzyscTextBoxy();
            trackBar1.Enabled = false;
            trackBar1.Maximum = 0;
            trackBar1.Minimum = 0;
            trackBar1.SmallChange = 0;
            trackBar1.TickFrequency = 0;
            trackBar1.Value = 0;
            label3.ForeColor = Color.DarkBlue;
            label3.Text = "".ToString();


            for (int i = 1; i <= 49; i++)
            {
                foreach (Control c in tabPage2.Controls)
                {
                    if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                    {
                        c.Enabled = false;
                        c.BackColor = Color.DarkGray;
                    }
                }
            }

            if (comboBox1.SelectedItem.ToString() != "FILTRACJA")
            {
                filtracja = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                label5.ForeColor = Color.DarkGray;
                label6.ForeColor = Color.DarkGray;
                label7.ForeColor = Color.DarkGray;
            }
        }

        public void UstawElementy()
        {
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5 || comboBox1.SelectedIndex == 6 || comboBox1.SelectedIndex == 7)
            {
                ZablokujElementy();
                trackBar1.Enabled = true;
                trackBar1.Maximum = 255;
                trackBar1.Minimum = -255;
                trackBar1.SmallChange = 5;
                trackBar1.TickFrequency = 5;
                trackBar1.Value = 0;
                label3.ForeColor = Color.DarkBlue;
                label3.Text = "0".ToString();
            }
            if (comboBox1.SelectedItem.ToString() == "BINARYZACJA")
            {
                ZablokujElementy();
                trackBar1.Enabled = true;
                trackBar1.Maximum = 255;
                trackBar1.Minimum = 0;
                trackBar1.SmallChange = 5;
                trackBar1.TickFrequency = 5;
                trackBar1.Value = 0;
                label3.ForeColor = Color.DarkBlue;
                label3.Text = "0".ToString();
            }
            if (label5.ForeColor == Color.DarkGreen || comboBox1.SelectedItem.ToString() == "FILTRACJA")
            {
                if (filtracja == false)
                {
                    label5.ForeColor = Color.DarkGreen;
                    label6.ForeColor = Color.DarkRed;
                    label7.ForeColor = Color.DarkRed;
                    label5.Enabled = true;
                    label6.Enabled = true;
                    label7.Enabled = true;

                    filtracja = true;
                }

                for (int i = 1; i <= 17; i++)
                {
                    foreach (Control c in tabPage2.Controls)
                    {
                        if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            c.Enabled = true;
                            c.BackColor = Color.White;
                        }
                    }
                    if (i == 3 || i == 10)
                    {
                        i += 4;
                    }
                }

                trackBar1.Enabled = true;
                trackBar1.Maximum = 39;
                trackBar1.Minimum = 0;
                trackBar1.SmallChange = 1;
                trackBar1.TickFrequency = 1;
                trackBar1.Value = 0;
                label3.ForeColor = Color.DarkBlue;
                label3.Text = "Maska niestandardowa".ToString();

                tabControl1.SelectedTab = tabPage2;
                opcja = 12;
            }
            if (label6.ForeColor == Color.DarkGreen)
            {
                label5.ForeColor = Color.DarkRed;
                label6.ForeColor = Color.DarkGreen;
                label7.ForeColor = Color.DarkRed;

                for (int i = 1; i <= 33; i++)
                {
                    foreach (Control c in tabPage2.Controls)
                    {
                        if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            c.Enabled = true;
                            c.BackColor = Color.White;
                        }
                    }
                    if (i == 5 || i == 12 || i == 19 || i == 26)
                    {
                        i += 2;
                    }
                }

                trackBar1.Enabled = true;
                trackBar1.Maximum = 7;
                trackBar1.Minimum = 0;
                trackBar1.SmallChange = 1;
                trackBar1.TickFrequency = 1;
                trackBar1.Value = 0;
                label3.ForeColor = Color.DarkBlue;
                label3.Text = "Maska niestandardowa".ToString();

                tabControl1.SelectedTab = tabPage2;
                opcja = 13;
            }
            if (label7.ForeColor == Color.DarkGreen)
            {
                label5.ForeColor = Color.DarkRed;
                label6.ForeColor = Color.DarkRed;
                label7.ForeColor = Color.DarkGreen;

                for (int i = 1; i <= 49; i++)
                {
                    foreach (Control c in tabPage2.Controls)
                    {
                        if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            c.Enabled = true;
                            c.BackColor = Color.White;
                        }
                    }
                }

                trackBar1.Enabled = true;
                trackBar1.Maximum = 1;
                trackBar1.Minimum = 0;
                trackBar1.SmallChange = 1;
                trackBar1.TickFrequency = 1;
                trackBar1.Value = 0;
                label3.ForeColor = Color.DarkBlue;
                label3.Text = "Maska niestandardowa".ToString();

                tabControl1.SelectedTab = tabPage2;
                opcja = 14;
            }
        }

        public void ResetujObraz()
        {
            Color piksel;
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    piksel = obraz1.GetPixel(i, j);
                    R = piksel.R;
                    G = piksel.G;
                    B = piksel.B;
                    obraz2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            pictureBox2.Image = obraz2;
            postep = 0;
            watek.Abort();
        }

        public void ModyfikujObraz()
        {
            if (opcja == 0)
            {
                ResetujObraz();
            }
            else if (opcja == 1)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = piksel.R;
                        G = 0;
                        B = 0;

                        R += trackBar1.Value;
                        if (R > 255)
                        {
                            R = 255;
                        }
                        else if (R < 0)
                        {
                            R = 0;
                        }
                        obraz2.SetPixel(i, j, Color.FromArgb(R, 0, 0));
                    }
                }
            }
            else if (opcja == 2)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = 0;
                        G = piksel.G;
                        B = 0;

                        G += trackBar1.Value;
                        if (G > 255)
                        {
                            G = 255;
                        }
                        else if (G < 0)
                        {
                            G = 0;
                        }
                        obraz2.SetPixel(i, j, Color.FromArgb(0, G, 0));
                    }
                }
            }
            else if (opcja == 3)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = 0;
                        G = 0;
                        B = piksel.B;

                        B += trackBar1.Value;
                        if (B > 255)
                        {
                            B = 255;
                        }
                        else if (B < 0)
                        {
                            B = 0;
                        }
                        obraz2.SetPixel(i, j, Color.FromArgb(0, 0, B));
                    }
                }
            }
            else if (opcja == 4)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = piksel.R;
                        G = piksel.G;
                        B = piksel.B;
                        S = (R + G + B) / 3;

                        S += trackBar1.Value;
                        if (S > 255)
                        {
                            S = 255;
                        }
                        else if (S < 0)
                        {
                            S = 0;
                        }
                        obraz2.SetPixel(i, j, Color.FromArgb(S, S, S));
                    }
                }
            }
            else if (opcja == 5)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = 0;
                        G = piksel.G;
                        B = piksel.B;

                        G += trackBar1.Value;
                        B += trackBar1.Value;
                        if (G > 255)
                        {
                            G = 255;
                        }
                        else if (G < 0)
                        {
                            G = 0;
                        }
                        if (B > 255)
                        {
                            B = 255;
                        }
                        else if (B < 0)
                        {
                            B = 0;
                        }
                        obraz2.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }
            }
            else if (opcja == 6)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = piksel.R;
                        G = 0;
                        B = piksel.B;

                        R += trackBar1.Value;
                        B += trackBar1.Value;
                        if (R > 255)
                        {
                            R = 255;
                        }
                        else if (R < 0)
                        {
                            R = 0;
                        }
                        if (B > 255)
                        {
                            B = 255;
                        }
                        else if (B < 0)
                        {
                            B = 0;
                        }
                        obraz2.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }
            }
            else if (opcja == 7)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = piksel.R;
                        G = piksel.G;
                        B = 0;

                        R += trackBar1.Value;
                        G += trackBar1.Value;
                        if (R > 255)
                        {
                            R = 255;
                        }
                        else if (R < 0)
                        {
                            R = 0;
                        }
                        if (G > 255)
                        {
                            G = 255;
                        }
                        else if (G < 0)
                        {
                            G = 0;
                        }
                        obraz2.SetPixel(i, j, Color.FromArgb(R, G, B));
                    }
                }
            }
            else if (opcja == 8)
            {
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        obraz2.SetPixel(i, j, Color.Black);
                    }
                }
            }
            else if (opcja == 9)
            {
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        obraz2.SetPixel(i, j, Color.White);
                    }
                }
            }
            else if (opcja == 10)
            {
                Random losuj = new Random();
                Color kolor = Color.FromArgb(losuj.Next(256), losuj.Next(256), losuj.Next(256));
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        obraz2.SetPixel(i, j, kolor);
                    }
                }
            }
            else if (opcja == 11)
            {
                Color piksel;
                for (int i = x1; i < x2; i++)
                {
                    for (int j = y1; j < y2; j++)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = piksel.R;
                        G = piksel.G;
                        B = piksel.B;
                        S = (R + G + B) / 3;
                        if (S < trackBar1.Value)
                        {
                            obraz2.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                        else
                        {
                            obraz2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                    }
                }
            }
            else if (opcja == 12)
            {
                int skladowaR = 0, skladowaG = 0, skladowaB = 0, suma = 0,
                    a = 0, b = 0, c = 0, w = 0, r = 0, n = 0, x = 0;
                bool maska = true;
                Color[] p = new Color[9];
                int[] tb = new int[9];

                UstawKolor3();
                for (int i = 1; i <= 17; i++)
                {
                    foreach (Control cc in tabPage2.Controls)
                    {
                        if (cc is TextBox && cc.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            try
                            {
                                cc.BackColor = Color.Red;
                                tb[x] = Convert.ToInt16(cc.Text);
                                cc.BackColor = Color.LightGreen;
                                x++;
                            }
                            catch
                            {
                                cc.Text = "";
                                if (maska == true)
                                {
                                    maska = false;
                                }
                            }
                        }
                    }
                    if (i == 3 || i == 10)
                    {
                        i += 4;
                    }
                }

                if (maska)
                {
                    for (int i = x1; i < x2; i++)
                    {
                        for (int j = y1; j < y2; j++)
                        {
                            skladowaR = 0;
                            skladowaG = 0;
                            skladowaB = 0;
                            suma = 0;

                            n = 0;
                            for (r = (j - 1); r <= (j + 1); r++)
                            {
                                for (w = (i - 1); w <= (i + 1); w++)
                                {
                                    int t1 = w, t2 = r;
                                    if (w < 0)
                                    {
                                        t1 = 0;
                                    }
                                    if (r < 0)
                                    {
                                        t2 = 0;
                                    }
                                    if (w >= obraz1.Width)
                                    {
                                        t1 = obraz1.Width - 1;
                                    }
                                    if (r >= obraz1.Height)
                                    {
                                        t2 = obraz1.Height - 1;
                                    }
                                    if (zrodlo == true)
                                    {
                                        p[n] = obraz1.GetPixel(t1, t2);
                                    }
                                    else
                                    {
                                        p[n] = obraz2.GetPixel(t1, t2);
                                    }

                                    skladowaR += (tb[n] * p[n].R);
                                    skladowaG += (tb[n] * p[n].G);
                                    skladowaB += (tb[n] * p[n].B);
                                    suma += tb[n];

                                    n++;
                                }
                            }

                            if (suma == 0)
                            {
                                a = skladowaR;
                            }
                            else
                            {
                                a = skladowaR / suma;
                            }

                            if (suma == 0)
                            {
                                b = skladowaG;
                            }
                            else
                            {
                                b = skladowaG / suma;
                            }

                            if (suma == 0)
                            {
                                c = skladowaB;
                            }
                            else
                            {
                                c = skladowaB / suma;
                            }

                            if (a < 0)
                            {
                                a = 0;
                            }
                            if (a > 255)
                            {
                                a = 255;
                            }
                            if (b < 0)
                            {
                                b = 0;
                            }
                            if (b > 255)
                            {
                                b = 255;
                            }
                            if (c < 0)
                            {
                                c = 0;
                            }
                            if (c > 255)
                            {
                                c = 255;
                            }
                            obraz2.SetPixel(i, j, Color.FromArgb(a, b, c));
                        }
                    }
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            else if (opcja == 13)
            {
                int skladowaR = 0, skladowaG = 0, skladowaB = 0, suma = 0,
                    a = 0, b = 0, c = 0, w = 0, r = 0, n = 0, x = 0;
                bool maska = true;
                Color[] p = new Color[25];
                int[] tb = new int[25];

                UstawKolor5();
                for (int i = 1; i <= 33; i++)
                {
                    foreach (Control cc in tabPage2.Controls)
                    {
                        if (cc is TextBox && cc.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            try
                            {
                                cc.BackColor = Color.Red;
                                tb[x] = Convert.ToInt16(cc.Text);
                                cc.BackColor = Color.LightGreen;
                                x++;
                            }
                            catch
                            {
                                cc.Text = "";
                                if (maska == true)
                                {
                                    maska = false;
                                }
                            }
                        }
                    }
                    if (i == 5 || i == 12 || i == 19 || i == 26)
                    {
                        i += 2;
                    }
                }

                if (maska)
                {
                    for (int i = x1; i < x2; i++)
                    {
                        for (int j = y1; j < y2; j++)
                        {
                            skladowaR = 0;
                            skladowaG = 0;
                            skladowaB = 0;
                            suma = 0;

                            n = 0;
                            for (r = (j - 2); r <= (j + 2); r++)
                            {
                                for (w = (i - 2); w <= (i + 2); w++)
                                {
                                    int t1 = w, t2 = r;
                                    if (w < 0)
                                    {
                                        t1 = 0;
                                    }
                                    if (r < 0)
                                    {
                                        t2 = 0;
                                    }
                                    if (w >= obraz1.Width)
                                    {
                                        t1 = obraz1.Width - 1;
                                    }
                                    if (r >= obraz1.Height)
                                    {
                                        t2 = obraz1.Height - 1;
                                    }
                                    if (zrodlo == true)
                                    {
                                        p[n] = obraz1.GetPixel(t1, t2);
                                    }
                                    else
                                    {
                                        p[n] = obraz2.GetPixel(t1, t2);
                                    }

                                    skladowaR += (tb[n] * p[n].R);
                                    skladowaG += (tb[n] * p[n].G);
                                    skladowaB += (tb[n] * p[n].B);
                                    suma += tb[n];

                                    n++;
                                }
                            }

                            if (suma == 0)
                            {
                                a = skladowaR;
                            }
                            else
                            {
                                a = skladowaR / suma;
                            }

                            if (suma == 0)
                            {
                                b = skladowaG;
                            }
                            else
                            {
                                b = skladowaG / suma;
                            }

                            if (suma == 0)
                            {
                                c = skladowaB;
                            }
                            else
                            {
                                c = skladowaB / suma;
                            }

                            if (a < 0)
                            {
                                a = 0;
                            }
                            if (a > 255)
                            {
                                a = 255;
                            }
                            if (b < 0)
                            {
                                b = 0;
                            }
                            if (b > 255)
                            {
                                b = 255;
                            }
                            if (c < 0)
                            {
                                c = 0;
                            }
                            if (c > 255)
                            {
                                c = 255;
                            }
                            obraz2.SetPixel(i, j, Color.FromArgb(a, b, c));
                        }
                    }
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            else if (opcja == 14)
            {
                int skladowaR = 0, skladowaG = 0, skladowaB = 0, suma = 0,
                    a = 0, b = 0, c = 0, w = 0, r = 0, n = 0, x = 0;
                bool maska = true;
                Color[] p = new Color[49];
                int[] tb = new int[49];

                UstawKolor7();
                for (int i = 1; i <= 49; i++)
                {
                    foreach (Control cc in tabPage2.Controls)
                    {
                        if (cc is TextBox && cc.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            try
                            {
                                cc.BackColor = Color.Red;
                                tb[x] = Convert.ToInt16(cc.Text);
                                cc.BackColor = Color.LightGreen;
                                x++;
                            }
                            catch
                            {
                                cc.Text = "";
                                if (maska == true)
                                {
                                    maska = false;
                                }
                            }
                        }
                    }
                }

                if (maska)
                {
                    for (int i = x1; i < x2; i++)
                    {
                        for (int j = y1; j < y2; j++)
                        {
                            skladowaR = 0;
                            skladowaG = 0;
                            skladowaB = 0;
                            suma = 0;

                            n = 0;
                            for (r = (j - 3); r <= (j + 3); r++)
                            {
                                for (w = (i - 3); w <= (i + 3); w++)
                                {
                                    int t1 = w, t2 = r;
                                    if (w < 0)
                                    {
                                        t1 = 0;
                                    }
                                    if (r < 0)
                                    {
                                        t2 = 0;
                                    }
                                    if (w >= obraz1.Width)
                                    {
                                        t1 = obraz1.Width - 1;
                                    }
                                    if (r >= obraz1.Height)
                                    {
                                        t2 = obraz1.Height - 1;
                                    }
                                    if (zrodlo == true)
                                    {
                                        p[n] = obraz1.GetPixel(t1, t2);
                                    }
                                    else
                                    {
                                        p[n] = obraz2.GetPixel(t1, t2);
                                    }

                                    skladowaR += (tb[n] * p[n].R);
                                    skladowaG += (tb[n] * p[n].G);
                                    skladowaB += (tb[n] * p[n].B);
                                    suma += tb[n];

                                    n++;
                                }
                            }

                            if (suma == 0)
                            {
                                a = skladowaR;
                            }
                            else
                            {
                                a = skladowaR / suma;
                            }

                            if (suma == 0)
                            {
                                b = skladowaG;
                            }
                            else
                            {
                                b = skladowaG / suma;
                            }

                            if (suma == 0)
                            {
                                c = skladowaB;
                            }
                            else
                            {
                                c = skladowaB / suma;
                            }

                            if (a < 0)
                            {
                                a = 0;
                            }
                            if (a > 255)
                            {
                                a = 255;
                            }
                            if (b < 0)
                            {
                                b = 0;
                            }
                            if (b > 255)
                            {
                                b = 255;
                            }
                            if (c < 0)
                            {
                                c = 0;
                            }
                            if (c > 255)
                            {
                                c = 255;
                            }
                            obraz2.SetPixel(i, j, Color.FromArgb(a, b, c));
                        }
                    }
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            pictureBox2.Image = obraz2;
            postep = 0;
            watek.Abort();
        }

        public void OdwrocKolory()
        {
            Color piksel;
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    if (zrodlo == true)
                    {
                        piksel = obraz1.GetPixel(i, j);
                    }
                    else
                    {
                        piksel = obraz2.GetPixel(i, j);
                    }
                    R = 255 - piksel.R;
                    G = 255 - piksel.G;
                    B = 255 - piksel.B;

                    obraz2.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
            pictureBox2.Image = obraz2;
            postep = 0;
            watek.Abort();
        }

        public void WybierzMaske3()
        {
            if (label5.ForeColor != Color.DarkGreen)
            {
                label5.ForeColor = Color.DarkGreen;
                label6.ForeColor = Color.DarkRed;
                label7.ForeColor = Color.DarkRed;
                ZablokujElementy();
                UstawElementy();
            }
        }

        public void WybierzMaske5()
        {
            if (label6.ForeColor != Color.DarkGreen)
            {
                label5.ForeColor = Color.DarkRed;
                label6.ForeColor = Color.DarkGreen;
                label7.ForeColor = Color.DarkRed;
                ZablokujElementy();
                UstawElementy();
            }
        }

        public void WybierzMaske7()
        {
            if (label7.ForeColor != Color.DarkGreen)
            {
                label5.ForeColor = Color.DarkRed;
                label6.ForeColor = Color.DarkRed;
                label7.ForeColor = Color.DarkGreen;
                ZablokujElementy();
                UstawElementy();
            }
        }

        public void UstawKolor3()
        {
            for (int i = 1; i <= 17; i++)
            {
                foreach (Control c in tabPage2.Controls)
                {
                    if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                    {
                        c.BackColor = Color.White;
                    }
                }
                if (i == 3 || i == 10)
                {
                    i += 4;
                }
            }
        }

        public void UstawKolor5()
        {
            for (int i = 1; i <= 33; i++)
            {
                foreach (Control c in tabPage2.Controls)
                {
                    if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                    {
                        c.BackColor = Color.White;
                    }
                }
                if (i == 5 || i == 12 || i == 19 || i == 26)
                {
                    i += 2;
                }
            }
        }

        public void UstawKolor7()
        {
            for (int i = 1; i <= 49; i++)
            {
                foreach (Control c in tabPage2.Controls)
                {
                    if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                    {
                        c.BackColor = Color.White;
                    }
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = false;
            comboBox1.Text = "PRZYWRÓĆ ORYGINALNY KOLOR";
            label3.Text = "NACIŚNIJ KLAWISZ F1";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (postep == 0)
                {
                    if (esc == false)
                    {
                        label3.Text = "NACIŚNIJ KLAWISZ F1";
                        this.Enabled = false;
                        esc = true;
                    }
                    else
                    {
                        label3.Text = "";
                        if (trackBar1.Value != 0)
                        {
                            label3.Text = Convert.ToString(trackBar1.Value);
                        }
                        this.Enabled = true;
                        esc = false;
                    }
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("Skróty klawiszowe:\n\nESC - Odblokuj/Zablokuj program.\nF1 - Wyświetl to okienko pomocy.\nF2 - Wyświetl informacje o programie.\n\nB - Importuje obraz o nazwie 'BAZOWY'.\nP - Modyfikuje obraz z wybranymi ustawieniami.\nZ - Zapisuje/Nadpisuje zmodyfikowany obraz o nazwie 'ZMIENIONY'.\n\nQ - Wybierz poprzedni element na liście.\nE - Wybierz następny element na liście.\n\nS - Zmniejsz wartość pola numerycznego o 1.\nW - Zwiększ wartość pola numerycznego o 1.\n\nA - Zmniejsz wartość suwaka o 1.\nD - Zwiększ wartość suwaka o 1.\n\nY - Wyłącz/Włącz pobieranie koloru z obrazu bazowego.\nO - Odwraca kolory obrazu.\nR - Przywróć oryginalny kolor.\n\nF4 - Przełącz między obrazem zmienionym a ustawieniami filtracji.\nF6 - Wyczyść wszystkie pola tekstowe odpowiedzialne za filtacje.\nF3 - Wybierz maskę 3X3.\nF5 - Wybierz maskę 5X5.\nF7 - Wybierz maskę 7X7.");
            }
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Poniżej znajduje się link do strony, z której wykorzystałem wszystkie potrzebne wzory do zastosowania wybranych filtrów obecnych w tym programie oraz dane dotyczące wartości poszczególnych masek:\n\nhttp://www.algorytm.org/przetwarzanie-obrazow/filtrowanie-obrazow.html\nMichał Skowron");
            }
            if (e.KeyCode == Keys.B)
            {
                bool plik = false;

                if (esc == false)
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile("BAZOWY.JPEG");
                        pictureBox2.Image = Image.FromFile("BAZOWY.JPEG");
                        plik = true;
                    }
                    catch
                    {
                        try
                        {
                            pictureBox1.Image = Image.FromFile("BAZOWY.JPG");
                            pictureBox2.Image = Image.FromFile("BAZOWY.JPG");
                            plik = true;
                        }
                        catch
                        {
                            try
                            {
                                pictureBox1.Image = Image.FromFile("BAZOWY.PNG");
                                pictureBox2.Image = Image.FromFile("BAZOWY.PNG");
                                plik = true;
                            }
                            catch
                            {
                                try
                                {
                                    pictureBox1.Image = Image.FromFile("BAZOWY.BMP");
                                    pictureBox2.Image = Image.FromFile("BAZOWY.BMP");
                                    plik = true;
                                }
                                catch
                                {
                                    MessageBox.Show("Nie odnaleziono pliku:\n'BAZOWY.JPEG', 'BAZOWY.JPG', 'BAZOWY.PNG' lub 'BAZOWY.BMP'.");
                                    plik = false;
                                }
                            }
                        }
                    }

                    if (plik == true)
                    {
                        obraz1 = (Bitmap)pictureBox1.Image;
                        obraz2 = (Bitmap)pictureBox2.Image;

                        szerokosc = obraz1.Width;
                        wysokosc = obraz1.Height;

                        podzial1 = szerokosc / 3;
                        podzial2 = wysokosc / 3;

                        button2.Enabled = true;
                        button3.Enabled = true;
                        comboBox1.Enabled = true;
                        label4.Enabled = true;
                        label8.Text = "???";
                        richTextBox1.Clear();
                        label9.Enabled = true;
                        numericUpDown1.Enabled = true;
                        numericUpDown1.Value = 0;
                    }
                }
            }
            if (e.KeyCode == Keys.P)
            {
                if (esc == false && button3.Enabled == true)
                {
                    UruchomWatek(1);
                }
            }
            if (e.KeyCode == Keys.Z)
            {
                if (esc == false && button2.Enabled == true)
                {
                    pictureBox2.Image.Save("ZMIENIONY.JPEG");
                    MessageBox.Show("Zapisano plik");
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                if (comboBox1.Enabled == true)
                {
                    try
                    {
                        if (comboBox1.SelectedIndex != 0)
                        {
                            comboBox1.SelectedIndex -= 1;
                        }
                    }
                    catch
                    {

                    }
                }
            }
            if (e.KeyCode == Keys.E)
            {
                if (comboBox1.Enabled == true)
                {
                    try
                    {
                        comboBox1.SelectedIndex += 1;
                    }
                    catch
                    {

                    }
                }
            }
            if (e.KeyCode == Keys.S)
            {
                if (numericUpDown1.Enabled == true)
                {
                    try
                    {
                        numericUpDown1.Value -= 1;
                    }
                    catch
                    {

                    }
                }
            }
            if (e.KeyCode == Keys.W)
            {
                if (numericUpDown1.Enabled == true)
                {
                    try
                    {
                        numericUpDown1.Value += 1;
                    }
                    catch
                    {

                    }
                }
            }
            if (e.KeyCode == Keys.A)
            {
                if (trackBar1.Enabled == true)
                {
                    try
                    {
                        trackBar1.Value -= 1;
                    }
                    catch
                    {

                    }
                }
            }
            if (e.KeyCode == Keys.D)
            {
                if (trackBar1.Enabled == true)
                {
                    try
                    {
                        trackBar1.Value += 1;
                    }
                    catch
                    {

                    }
                }
            }
            if (e.KeyCode == Keys.Y)
            {
                if (esc == false)
                {
                    if (zrodlo == false)
                    {
                        MessageBox.Show("Włączono pobieranie koloru z obrazu bazowego.");
                        zrodlo = true;
                    }
                    else
                    {
                        MessageBox.Show("Wyłączono pobieranie koloru z obrazu bazowego.");
                        zrodlo = false;
                    }
                }
            }
            if (e.KeyCode == Keys.O)
            {
                if (esc == false)
                {
                    UruchomWatek(2);
                }
            }
            if (e.KeyCode == Keys.R)
            {
                if (esc == false)
                {
                    UruchomWatek(3);
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (esc == false)
                {
                    if (tabControl1.SelectedTab == tabPage1)
                    {
                        tabControl1.SelectedTab = tabPage2;
                    }
                    else
                    {
                        tabControl1.SelectedTab = tabPage1;
                    }
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                if (esc == false)
                {
                    CzyscTextBoxy();
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                if (esc == false)
                {
                    WybierzMaske3();
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (esc == false)
                {
                    WybierzMaske5();
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                if (esc == false)
                {
                    WybierzMaske7();
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            for (int i = 1; i <= 49; i++)
            {
                foreach (Control c in tabPage2.Controls)
                {
                    if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                    {
                        e.Handled = char.IsLetter(e.KeyChar);
                    }
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "PRZYWRÓĆ ORYGINALNY KOLOR")
            {
                ZablokujElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 0;
            }
            if (comboBox1.SelectedItem.ToString() == "POZOSTAW TYLKO KOLOR CZERWONY")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 1;
            }
            if (comboBox1.SelectedItem.ToString() == "POZOSTAW TYLKO KOLOR ZIELONY")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 2;
            }
            if (comboBox1.SelectedItem.ToString() == "POZOSTAW TYLKO KOLOR NIEBIESKI")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 3;
            }
            if (comboBox1.SelectedItem.ToString() == "POZOSTAW TYLKO ODCIENIE SZAROŚCI")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 4;
            }
            if (comboBox1.SelectedItem.ToString() == "USUŃ KOLOR CZERWONY")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 5;
            }
            if (comboBox1.SelectedItem.ToString() == "USUŃ KOLOR ZIELONY")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 6;
            }
            if (comboBox1.SelectedItem.ToString() == "USUŃ KOLOR NIEBIESKI")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 7;
            }
            if (comboBox1.SelectedItem.ToString() == "WYPEŁNIJ KOLOREM CZARNYM")
            {
                ZablokujElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 8;
            }
            if (comboBox1.SelectedItem.ToString() == "WYPEŁNIJ KOLOREM BIAŁYM")
            {
                ZablokujElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 9;
            }
            if (comboBox1.SelectedItem.ToString() == "WYPEŁNIJ LOSOWYM KOLOREM")
            {
                ZablokujElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 10;
            }
            if (comboBox1.SelectedItem.ToString() == "BINARYZACJA")
            {
                ZablokujElementy();
                UstawElementy();

                tabControl1.SelectedTab = tabPage1;
                opcja = 11;
            }
            if (comboBox1.SelectedItem.ToString() == "FILTRACJA")
            {
                ZablokujElementy();
                UstawElementy();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value.Equals(0))
            {
                x1 = 0;
                x2 = szerokosc;
                y1 = 0;
                y2 = wysokosc;
            }
            if (numericUpDown1.Value.Equals(1))
            {
                x1 = 0;
                x2 = podzial1;
                y1 = 0;
                y2 = podzial2;
            }
            if (numericUpDown1.Value.Equals(2))
            {
                x1 = podzial1;
                x2 = 2 * podzial1;
                y1 = 0;
                y2 = podzial2;
            }
            if (numericUpDown1.Value.Equals(3))
            {
                x1 = 2 * podzial1;
                x2 = 3 * podzial1;
                y1 = 0;
                y2 = podzial2;
            }
            if (numericUpDown1.Value.Equals(4))
            {
                x1 = 0;
                x2 = podzial1;
                y1 = podzial2;
                y2 = 2 * podzial2;
            }
            if (numericUpDown1.Value.Equals(5))
            {
                x1 = podzial1;
                x2 = 2 * podzial1;
                y1 = podzial2;
                y2 = 2 * podzial2;
            }
            if (numericUpDown1.Value.Equals(6))
            {
                x1 = 2 * podzial1;
                x2 = 3 * podzial1;
                y1 = podzial2;
                y2 = 2 * podzial2;
            }
            if (numericUpDown1.Value.Equals(7))
            {
                x1 = 0;
                x2 = podzial1;
                y1 = 2 * podzial2;
                y2 = 3 * podzial2;
            }
            if (numericUpDown1.Value.Equals(8))
            {
                x1 = podzial1;
                x2 = 2 * podzial1;
                y1 = 2 * podzial2;
                y2 = 3 * podzial2;
            }
            if (numericUpDown1.Value.Equals(9))
            {
                x1 = 2 * podzial1;
                x2 = 3 * podzial1;
                y1 = 2 * podzial2;
                y2 = 3 * podzial2;
            }
            if (numericUpDown1.Value.Equals(10))
            {
                x1 = 0;
                x2 = szerokosc;
                y1 = 0;
                y2 = 5;
            }
            if (numericUpDown1.Value.Equals(11))
            {
                x1 = szerokosc - 5;
                x2 = szerokosc;
                y1 = 0;
                y2 = wysokosc;
            }
            if (numericUpDown1.Value.Equals(12))
            {
                x1 = 0;
                x2 = szerokosc;
                y1 = wysokosc - 5;
                y2 = wysokosc;
            }
            if (numericUpDown1.Value.Equals(13))
            {
                x1 = 0;
                x2 = 5;
                y1 = 0;
                y2 = wysokosc;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (trackBar1.Value != wartosc)
            {
                if (trackBar1.Value > 0)
                {
                    label3.ForeColor = Color.DarkGreen;
                }
                else if (trackBar1.Value < 0)
                {
                    label3.ForeColor = Color.DarkRed;
                }
                else
                {
                    label3.ForeColor = Color.DarkBlue;
                }
                label3.Text = trackBar1.Value.ToString();
                wartosc = trackBar1.Value;

                if (comboBox1.SelectedItem.ToString() == "FILTRACJA")
                {
                    tabControl1.SelectedTab = tabPage2;
                }
            }
            if (trackBar1.Value == 0)
            {
                CzyscTextBoxy();
                if (comboBox1.SelectedItem.ToString() == "FILTRACJA")
                {
                    label3.Text = "Maska niestandardowa".ToString();
                }
                else if (comboBox1.SelectedItem.ToString() == "BINARYZACJA")
                {
                    label3.Text = "0".ToString();
                }
            }

            if (trackBar1.Value == 1 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                for (int i = 1; i <= 17; i++)
                {
                    foreach (Control c in tabPage2.Controls)
                    {
                        if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            c.Text = "1";
                        }
                    }
                    if (i == 3 || i == 10)
                    {
                        i += 4;
                    }
                }

                label3.Text = "Filtr dolnoprzepustowy - filtr uśredniający".ToString();
            }
            if (trackBar1.Value == 2 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "1";
                textBox9.Text = "2";
                textBox10.Text = "1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - LP1".ToString();
            }
            if (trackBar1.Value == 3 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "1";
                textBox9.Text = "4";
                textBox10.Text = "1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - LP2".ToString();
            }
            if (trackBar1.Value == 4 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "1";
                textBox9.Text = "12";
                textBox10.Text = "1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - LP3".ToString();
            }
            if (trackBar1.Value == 5 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "2";
                textBox3.Text = "1";

                textBox8.Text = "2";
                textBox9.Text = "4";
                textBox10.Text = "2";

                textBox15.Text = "1";
                textBox16.Text = "2";
                textBox17.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - gauss 1".ToString();
            }
            if (trackBar1.Value == 6 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "-1";

                textBox8.Text = "-1";
                textBox9.Text = "9";
                textBox10.Text = "-1";

                textBox15.Text = "-1";
                textBox16.Text = "-1";
                textBox17.Text = "-1";

                label3.Text = "Filtr górnoprzepustowy - usuń średnią".ToString();
            }
            if (trackBar1.Value == 7 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "-1";
                textBox3.Text = "0";

                textBox8.Text = "-1";
                textBox9.Text = "5";
                textBox10.Text = "-1";

                textBox15.Text = "0";
                textBox16.Text = "-1";
                textBox17.Text = "0";

                label3.Text = "Filtr górnoprzepustowy - HP1".ToString();
            }
            if (trackBar1.Value == 8 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "-2";
                textBox3.Text = "1";

                textBox8.Text = "-2";
                textBox9.Text = "5";
                textBox10.Text = "-2";

                textBox15.Text = "1";
                textBox16.Text = "-2";
                textBox17.Text = "1";

                label3.Text = "Filtr górnoprzepustowy - HP2".ToString();
            }
            if (trackBar1.Value == 9 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "-1";
                textBox3.Text = "0";

                textBox8.Text = "-1";
                textBox9.Text = "20";
                textBox10.Text = "-1";

                textBox15.Text = "0";
                textBox16.Text = "-1";
                textBox17.Text = "0";

                label3.Text = "Filtr górnoprzepustowy - HP3".ToString();
            }
            if (trackBar1.Value == 10 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";

                textBox8.Text = "-1";
                textBox9.Text = "1";
                textBox10.Text = "0";

                textBox15.Text = "0";
                textBox16.Text = "0";
                textBox17.Text = "0";

                label3.Text = "Filtr przesuwania i odejmowania - pionowy".ToString();
            }
            if (trackBar1.Value == 11 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "-1";
                textBox3.Text = "0";

                textBox8.Text = "0";
                textBox9.Text = "1";
                textBox10.Text = "0";

                textBox15.Text = "0";
                textBox16.Text = "0";
                textBox17.Text = "0";

                label3.Text = "Filtr przesuwania i odejmowania - poziomy".ToString();
            }
            if (trackBar1.Value == 12 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "0";
                textBox3.Text = "0";

                textBox8.Text = "0";
                textBox9.Text = "1";
                textBox10.Text = "0";

                textBox15.Text = "0";
                textBox16.Text = "0";
                textBox17.Text = "0";

                label3.Text = "Filtr przesuwania i odejmowania - ukośny /".ToString();
            }
            if (trackBar1.Value == 13 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "-1";

                textBox8.Text = "0";
                textBox9.Text = "1";
                textBox10.Text = "0";

                textBox15.Text = "0";
                textBox16.Text = "0";
                textBox17.Text = "0";

                label3.Text = "Filtr przesuwania i odejmowania - ukośny".ToString();
            }
            if (trackBar1.Value == 14 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "-1";
                textBox9.Text = "-2";
                textBox10.Text = "1";

                textBox15.Text = "-1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Gradientowy filtr kierunkowy - wschód".ToString();
            }
            if (trackBar1.Value == 15 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "1";

                textBox8.Text = "-1";
                textBox9.Text = "-2";
                textBox10.Text = "1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Gradientowy filtr kierunkowy - południowy wschód".ToString();
            }
            if (trackBar1.Value == 16 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "-1";

                textBox8.Text = "1";
                textBox9.Text = "-2";
                textBox10.Text = "1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Gradientowy filtr kierunkowy - południe".ToString();
            }
            if (trackBar1.Value == 17 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "-1";
                textBox3.Text = "-1";

                textBox8.Text = "1";
                textBox9.Text = "-2";
                textBox10.Text = "-1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Gradientowy filtr kierunkowy - południowy zachód".ToString();
            }
            if (trackBar1.Value == 18 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "-1";

                textBox8.Text = "1";
                textBox9.Text = "-2";
                textBox10.Text = "-1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "-1";

                label3.Text = "Gradientowy filtr kierunkowy - zachód".ToString();
            }
            if (trackBar1.Value == 19 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "1";
                textBox9.Text = "-2";
                textBox10.Text = "-1";

                textBox15.Text = "1";
                textBox16.Text = "-1";
                textBox17.Text = "-1";

                label3.Text = "Gradientowy filtr kierunkowy - północny zachód".ToString();
            }
            if (trackBar1.Value == 20 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "1";
                textBox9.Text = "-2";
                textBox10.Text = "1";

                textBox15.Text = "-1";
                textBox16.Text = "-1";
                textBox17.Text = "-1";

                label3.Text = "Gradientowy filtr kierunkowy - północ".ToString();
            }
            if (trackBar1.Value == 21 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "-1";
                textBox9.Text = "-2";
                textBox10.Text = "1";

                textBox15.Text = "-1";
                textBox16.Text = "-1";
                textBox17.Text = "1";

                label3.Text = "Gradientowy filtr kierunkowy - północny wschód".ToString();
            }
            if (trackBar1.Value == 22 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "0";
                textBox3.Text = "1";

                textBox8.Text = "-1";
                textBox9.Text = "1";
                textBox10.Text = "1";

                textBox15.Text = "-1";
                textBox16.Text = "0";
                textBox17.Text = "1";

                label3.Text = "Filtr uwypuklający - wschód".ToString();
            }
            if (trackBar1.Value == 23 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "0";

                textBox8.Text = "-1";
                textBox9.Text = "1";
                textBox10.Text = "1";

                textBox15.Text = "0";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Filtr uwypuklający - południowy wschód".ToString();
            }
            if (trackBar1.Value == 24 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "-1";

                textBox8.Text = "0";
                textBox9.Text = "1";
                textBox10.Text = "0";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Filtr uwypuklający - południe".ToString();
            }
            if (trackBar1.Value == 25 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "-1";
                textBox3.Text = "-1";

                textBox8.Text = "1";
                textBox9.Text = "1";
                textBox10.Text = "-1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "0";

                label3.Text = "Filtr uwypuklający - południowy zachód".ToString();
            }
            if (trackBar1.Value == 26 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "0";
                textBox3.Text = "-1";

                textBox8.Text = "1";
                textBox9.Text = "1";
                textBox10.Text = "-1";

                textBox15.Text = "1";
                textBox16.Text = "0";
                textBox17.Text = "-1";

                label3.Text = "Filtr uwypuklający - zachód".ToString();
            }
            if (trackBar1.Value == 27 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "0";

                textBox8.Text = "1";
                textBox9.Text = "1";
                textBox10.Text = "-1";

                textBox15.Text = "0";
                textBox16.Text = "-1";
                textBox17.Text = "-1";

                label3.Text = "Filtr uwypuklający - północny zachód".ToString();
            }
            if (trackBar1.Value == 28 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "0";
                textBox9.Text = "1";
                textBox10.Text = "0";

                textBox15.Text = "-1";
                textBox16.Text = "-1";
                textBox17.Text = "-1";

                label3.Text = "Filtr uwypuklający - północ".ToString();
            }
            if (trackBar1.Value == 29 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "1";
                textBox3.Text = "1";

                textBox8.Text = "-1";
                textBox9.Text = "1";
                textBox10.Text = "1";

                textBox15.Text = "-1";
                textBox16.Text = "-1";
                textBox17.Text = "0";

                label3.Text = "Filtr uwypuklający - północny wschód".ToString();
            }
            if (trackBar1.Value == 30 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "-1";
                textBox3.Text = "0";

                textBox8.Text = "-1";
                textBox9.Text = "4";
                textBox10.Text = "-1";

                textBox15.Text = "0";
                textBox16.Text = "-1";
                textBox17.Text = "0";

                label3.Text = "Filtr Laplace'a - LAPL1".ToString();
            }
            if (trackBar1.Value == 31 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "-1";

                textBox8.Text = "-1";
                textBox9.Text = "8";
                textBox10.Text = "-1";

                textBox15.Text = "-1";
                textBox16.Text = "-1";
                textBox17.Text = "-1";

                label3.Text = "Filtr Laplace'a - LAPL2".ToString();
            }
            if (trackBar1.Value == 32 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "-2";
                textBox3.Text = "1";

                textBox8.Text = "-2";
                textBox9.Text = "4";
                textBox10.Text = "-2";

                textBox15.Text = "1";
                textBox16.Text = "-2";
                textBox17.Text = "1";

                label3.Text = "Filtr Laplace'a - LAPL3".ToString();
            }
            if (trackBar1.Value == 33 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "0";
                textBox3.Text = "-1";

                textBox8.Text = "0";
                textBox9.Text = "4";
                textBox10.Text = "0";

                textBox15.Text = "-1";
                textBox16.Text = "0";
                textBox17.Text = "-1";

                label3.Text = "Filtr Laplace'a - ukośny".ToString();
            }
            if (trackBar1.Value == 34 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "-1";
                textBox3.Text = "0";

                textBox8.Text = "0";
                textBox9.Text = "2";
                textBox10.Text = "0";

                textBox15.Text = "0";
                textBox16.Text = "-1";
                textBox17.Text = "0";

                label3.Text = "Filtr Laplace'a - poziomy".ToString();
            }
            if (trackBar1.Value == 35 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";

                textBox8.Text = "-1";
                textBox9.Text = "2";
                textBox10.Text = "-1";

                textBox15.Text = "0";
                textBox16.Text = "0";
                textBox17.Text = "0";

                label3.Text = "Filtr Laplace'a - pionowy".ToString();
            }
            if (trackBar1.Value == 36 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "2";
                textBox3.Text = "1";

                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox10.Text = "0";

                textBox15.Text = "-1";
                textBox16.Text = "-2";
                textBox17.Text = "-1";

                label3.Text = "Filtr konturowy - poziomy filtr Sobel'a".ToString();
            }
            if (trackBar1.Value == 37 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "0";
                textBox3.Text = "-1";

                textBox8.Text = "2";
                textBox9.Text = "0";
                textBox10.Text = "-2";

                textBox15.Text = "1";
                textBox16.Text = "0";
                textBox17.Text = "-1";

                label3.Text = "Filtr konturowy - pionowy filtr Sobel'a".ToString();
            }
            if (trackBar1.Value == 38 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "-1";

                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox10.Text = "0";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";

                label3.Text = "Filtr konturowy - poziomy filtr Prewitt'a".ToString();
            }
            if (trackBar1.Value == 39 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label5.ForeColor == Color.DarkGreen)
            {
                UstawKolor3();

                textBox1.Text = "1";
                textBox2.Text = "0";
                textBox3.Text = "-1";

                textBox8.Text = "1";
                textBox9.Text = "0";
                textBox10.Text = "-1";

                textBox15.Text = "1";
                textBox16.Text = "0";
                textBox17.Text = "-1";

                label3.Text = "Filtr konturowy - pionowy filtr Prewitt'a".ToString();
            }

            if (trackBar1.Value == 1 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();

                for (int i = 1; i <= 33; i++)
                {
                    foreach (Control c in tabPage2.Controls)
                    {
                        if (c is TextBox && c.TabIndex == Convert.ToInt16(listBox1.Items[i - 1]))
                        {
                            c.Text = "1";
                        }
                    }
                    if (i == 5 || i == 12 || i == 19 || i == 26)
                    {
                        i += 2;
                    }
                }

                label3.Text = "Filtr dolnoprzepustowy - filtr kwadratowy".ToString();
            }
            if (trackBar1.Value == 2 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();

                textBox1.Text = "0";
                textBox2.Text = "1";
                textBox3.Text = "1";
                textBox4.Text = "1";
                textBox5.Text = "0";

                textBox8.Text = "1";
                textBox9.Text = "1";
                textBox10.Text = "1";
                textBox11.Text = "1";
                textBox12.Text = "1";

                textBox15.Text = "1";
                textBox16.Text = "1";
                textBox17.Text = "1";
                textBox18.Text = "1";
                textBox19.Text = "1";

                textBox22.Text = "1";
                textBox23.Text = "1";
                textBox24.Text = "1";
                textBox25.Text = "1";
                textBox26.Text = "1";

                textBox29.Text = "0";
                textBox30.Text = "1";
                textBox31.Text = "1";
                textBox32.Text = "1";
                textBox33.Text = "0";

                label3.Text = "Filtr dolnoprzepustowy - filtr kołowy".ToString();
            }
            if (trackBar1.Value == 3 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();

                textBox1.Text = "1";
                textBox2.Text = "2";
                textBox3.Text = "3";
                textBox4.Text = "2";
                textBox5.Text = "1";

                textBox8.Text = "2";
                textBox9.Text = "4";
                textBox10.Text = "6";
                textBox11.Text = "4";
                textBox12.Text = "2";

                textBox15.Text = "3";
                textBox16.Text = "6";
                textBox17.Text = "9";
                textBox18.Text = "6";
                textBox19.Text = "3";

                textBox22.Text = "2";
                textBox23.Text = "4";
                textBox24.Text = "6";
                textBox25.Text = "4";
                textBox26.Text = "2";

                textBox29.Text = "1";
                textBox30.Text = "2";
                textBox31.Text = "3";
                textBox32.Text = "2";
                textBox33.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - piramidalny".ToString();
            }
            if (trackBar1.Value == 4 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();

                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "1";
                textBox4.Text = "0";
                textBox5.Text = "0";

                textBox8.Text = "0";
                textBox9.Text = "2";
                textBox10.Text = "2";
                textBox11.Text = "2";
                textBox12.Text = "0";

                textBox15.Text = "1";
                textBox16.Text = "2";
                textBox17.Text = "5";
                textBox18.Text = "2";
                textBox19.Text = "1";

                textBox22.Text = "0";
                textBox23.Text = "2";
                textBox24.Text = "2";
                textBox25.Text = "2";
                textBox26.Text = "0";

                textBox29.Text = "0";
                textBox30.Text = "0";
                textBox31.Text = "1";
                textBox32.Text = "0";
                textBox33.Text = "0";

                label3.Text = "Filtr dolnoprzepustowy - stożkowy".ToString();
            }
            if (trackBar1.Value == 5 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "2";
                textBox4.Text = "1";
                textBox5.Text = "1";

                textBox8.Text = "1";
                textBox9.Text = "2";
                textBox10.Text = "4";
                textBox11.Text = "2";
                textBox12.Text = "1";

                textBox15.Text = "2";
                textBox16.Text = "4";
                textBox17.Text = "8";
                textBox18.Text = "4";
                textBox19.Text = "2";

                textBox22.Text = "1";
                textBox23.Text = "2";
                textBox24.Text = "4";
                textBox25.Text = "2";
                textBox26.Text = "1";

                textBox29.Text = "1";
                textBox30.Text = "1";
                textBox31.Text = "2";
                textBox32.Text = "1";
                textBox33.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - gauss 2".ToString();
            }
            if (trackBar1.Value == 6 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();

                textBox1.Text = "0";
                textBox2.Text = "1";
                textBox3.Text = "2";
                textBox4.Text = "1";
                textBox5.Text = "0";

                textBox8.Text = "1";
                textBox9.Text = "4";
                textBox10.Text = "8";
                textBox11.Text = "4";
                textBox12.Text = "1";

                textBox15.Text = "2";
                textBox16.Text = "8";
                textBox17.Text = "16";
                textBox18.Text = "8";
                textBox19.Text = "2";

                textBox22.Text = "1";
                textBox23.Text = "4";
                textBox24.Text = "8";
                textBox25.Text = "4";
                textBox26.Text = "1";

                textBox29.Text = "0";
                textBox30.Text = "1";
                textBox31.Text = "2";
                textBox32.Text = "1";
                textBox33.Text = "0";

                label3.Text = "Filtr dolnoprzepustowy - gauss 3".ToString();
            }
            if (trackBar1.Value == 7 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label6.ForeColor == Color.DarkGreen)
            {
                UstawKolor5();

                textBox1.Text = "1";
                textBox2.Text = "4";
                textBox3.Text = "7";
                textBox4.Text = "4";
                textBox5.Text = "1";

                textBox8.Text = "4";
                textBox9.Text = "16";
                textBox10.Text = "26";
                textBox11.Text = "16";
                textBox12.Text = "4";

                textBox15.Text = "7";
                textBox16.Text = "26";
                textBox17.Text = "41";
                textBox18.Text = "26";
                textBox19.Text = "7";

                textBox22.Text = "4";
                textBox23.Text = "16";
                textBox24.Text = "26";
                textBox25.Text = "16";
                textBox26.Text = "4";

                textBox29.Text = "1";
                textBox30.Text = "4";
                textBox31.Text = "7";
                textBox32.Text = "4";
                textBox33.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - gauss 4".ToString();
            }

            if (trackBar1.Value == 1 && comboBox1.SelectedItem.ToString() == "FILTRACJA" && label7.ForeColor == Color.DarkGreen)
            {
                UstawKolor7();

                textBox1.Text = "1";
                textBox2.Text = "1";
                textBox3.Text = "2";
                textBox4.Text = "2";
                textBox5.Text = "2";
                textBox6.Text = "1";
                textBox7.Text = "1";

                textBox8.Text = "1";
                textBox9.Text = "2";
                textBox10.Text = "2";
                textBox11.Text = "4";
                textBox12.Text = "2";
                textBox13.Text = "2";
                textBox14.Text = "1";

                textBox15.Text = "2";
                textBox16.Text = "2";
                textBox17.Text = "4";
                textBox18.Text = "8";
                textBox19.Text = "4";
                textBox20.Text = "2";
                textBox21.Text = "2";

                textBox22.Text = "2";
                textBox23.Text = "4";
                textBox24.Text = "8";
                textBox25.Text = "16";
                textBox26.Text = "8";
                textBox27.Text = "4";
                textBox28.Text = "2";

                textBox29.Text = "2";
                textBox30.Text = "2";
                textBox31.Text = "4";
                textBox32.Text = "8";
                textBox33.Text = "4";
                textBox34.Text = "2";
                textBox35.Text = "2";

                textBox36.Text = "1";
                textBox37.Text = "2";
                textBox38.Text = "2";
                textBox39.Text = "4";
                textBox40.Text = "2";
                textBox41.Text = "2";
                textBox42.Text = "1";

                textBox43.Text = "1";
                textBox44.Text = "1";
                textBox45.Text = "2";
                textBox46.Text = "2";
                textBox47.Text = "2";
                textBox48.Text = "1";
                textBox49.Text = "1";

                label3.Text = "Filtr dolnoprzepustowy - gauss 5".ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UruchomWatek(2);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WybierzMaske3();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            WybierzMaske5();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            WybierzMaske7();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog odczytaj = new OpenFileDialog();
            odczytaj.Filter = "JPG|*.jpg;|JPEG|*.jpeg;|PNG|*.png;|BMP|*.bmp";
            if (odczytaj.ShowDialog() == DialogResult.OK && odczytaj.FileName != "")
            {
                if (odczytaj.CheckFileExists)
                {
                    pictureBox1.Image = Image.FromFile(odczytaj.FileName);
                    pictureBox2.Image = Image.FromFile(odczytaj.FileName);

                    obraz1 = (Bitmap)pictureBox1.Image;
                    obraz2 = (Bitmap)pictureBox2.Image;

                    szerokosc = obraz1.Width;
                    wysokosc = obraz1.Height;

                    podzial1 = szerokosc / 3;
                    podzial2 = wysokosc / 3;

                    button2.Enabled = true;
                    button3.Enabled = true;
                    comboBox1.Enabled = true;
                    label4.Enabled = true;
                    label8.Text = "???";
                    richTextBox1.Clear();
                    label9.Enabled = true;
                    numericUpDown1.Enabled = true;
                    numericUpDown1.Value = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog zapisz = new SaveFileDialog();
            zapisz.Filter = "Plik graficzny|*.jpeg";
            if (zapisz.ShowDialog() == DialogResult.OK && zapisz.FileName != "")
            {
                pictureBox2.Image.Save(zapisz.FileName);
                MessageBox.Show("Zapisano plik");
            }
        }

        Thread watek;
        void UruchomWatek(int wybor)
        {
            this.Enabled = false;
            postep = 1;
            if (wybor == 1)
            {
                watek = new Thread(ModyfikujObraz);
                watek.Start();
            }
            if (wybor == 2)
            {
                watek = new Thread(OdwrocKolory);
                watek.Start();
            }
            if (wybor == 3)
            {
                watek = new Thread(ResetujObraz);
                watek.Start();
            }
            if (wybor == 4)
            {
                watek = new Thread(RozpoznajObiekt);
                watek.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UruchomWatek(1);
        }

        string kolorObiektu = "";
        string ksztaltObiektu = "";
        int wysokoscObiektu = 0;
        int szerokoscObiektu = 0;
        string teksturaObiektu = "";
        string nazwaObiektu = "???";
        int xMin = 1000000;
        int xMax = 0;
        int yMin = 1000000;
        int yMax = 0;

        void UstalKolorObiektu()
        {
            ushort licznikR = 0;
            ushort licznikO = 0;
            ushort licznikY = 0;
            ushort licznikG = 0;

            Color piksel;
            for (int i = x1; i < x2; i += 5)
            {
                for (int j = y1; j < y2; j += 5)
                {
                    if (i < obraz1.Width && j < obraz1.Height)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = piksel.R;
                        G = piksel.G;
                        B = piksel.B;
                        if (R >= 204)
                        {
                            if (G <= 102)
                            {
                                if (B <= 102)
                                {
                                    licznikR++;
                                }
                            }
                        }
                        if (R >= 204)
                        {
                            if (G >= 102 && G <= 178)
                            {
                                if (B <= 102)
                                {
                                    licznikO++;
                                }
                            }
                        }
                        if (R >= 230)
                        {
                            if (G >= 204)
                            {
                                if (B <= 102)
                                {
                                    licznikY++;
                                }
                            }
                        }
                        if (R <= 219)
                        {
                            if (G >= 204)
                            {
                                if (B <= 102)
                                {
                                    licznikG++;
                                }
                            }
                        }
                    }
                }
            }
            ushort max1 = Math.Max(licznikR, licznikO);
            ushort max2 = Math.Max(licznikY, licznikG);
            ushort max3 = Math.Max(max1, max2);
            if (licznikR == max3 && max3 != 0)
            {
                kolorObiektu = "CZERWONY";
            }
            else if (licznikO == max3 && max3 != 0)
            {
                kolorObiektu = "POMARAŃCZOWY";
            }
            else if (licznikY == max3 && max3 != 0)
            {
                kolorObiektu = "ŻÓŁTY";
            }
            else if (licznikG == max3 && max3 != 0)
            {
                kolorObiektu = "ZIELONY";
            }
            else
            {
                kolorObiektu = "???";
            }
        }

        void UstalKsztaltObiektu()
        {
            Color piksel;
            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    if (i < obraz1.Width && j < obraz1.Height)
                    {
                        if (zrodlo == true)
                        {
                            piksel = obraz1.GetPixel(i, j);
                        }
                        else
                        {
                            piksel = obraz2.GetPixel(i, j);
                        }
                        R = piksel.R;
                        G = piksel.G;
                        B = piksel.B;
                        if ((R != 255 && G != 255) && B != 255)
                        {
                            if (xMin > i)
                            {
                                xMin = i;
                            }
                            if (xMax < i)
                            {
                                xMax = i;
                            }
                            if (yMin > j)
                            {
                                yMin = j;
                            }
                            if (yMax < j)
                            {
                                yMax = j;
                            }
                        }
                    }
                }
            }
            wysokoscObiektu = yMax - yMin;
            szerokoscObiektu = xMax - xMin;
            int roznica = Math.Abs(wysokoscObiektu - szerokoscObiektu);
            if (roznica == 0)
            {
                ksztaltObiektu = "KWADRATOWY";
            }
            else if (roznica <= 40)
            {
                ksztaltObiektu = "OKRĄGŁY";
            }
            else if (roznica > 100)
            {
                ksztaltObiektu = "PODŁUŻNY";
            }
            else
            {
                ksztaltObiektu = "???";
            }
        }

        void UstalTekstureObiektu()
        {
            int skladowaR = 0, skladowaG = 0, skladowaB = 0, suma = 0,
                a = 0, b = 0, c = 0, w = 0, r = 0, n = 0;
            Color[] p = new Color[9];
            int[] tb = new int[9];
            tb[0] = -1; tb[1] = 0; tb[2] = -1;
            tb[3] = 0; tb[4] = 4; tb[5] = 0;
            tb[6] = -1; tb[7] = 0; tb[8] = -1;
            int licznik = 0;

            for (int i = x1; i < x2; i++)
            {
                for (int j = y1; j < y2; j++)
                {
                    skladowaR = 0;
                    skladowaG = 0;
                    skladowaB = 0;
                    suma = 0;

                    n = 0;
                    for (r = (j - 1); r <= (j + 1); r++)
                    {
                        for (w = (i - 1); w <= (i + 1); w++)
                        {
                            int t1 = w, t2 = r;
                            if (w < 0)
                            {
                                t1 = 0;
                            }
                            if (r < 0)
                            {
                                t2 = 0;
                            }
                            if (w >= obraz1.Width)
                            {
                                t1 = obraz1.Width - 1;
                            }
                            if (r >= obraz1.Height)
                            {
                                t2 = obraz1.Height - 1;
                            }
                            if (zrodlo == true)
                            {
                                p[n] = obraz1.GetPixel(t1, t2);
                            }
                            else
                            {
                                p[n] = obraz2.GetPixel(t1, t2);
                            }

                            skladowaR += (tb[n] * p[n].R);
                            skladowaG += (tb[n] * p[n].G);
                            skladowaB += (tb[n] * p[n].B);
                            suma += tb[n];

                            n++;
                        }
                    }

                    if (suma == 0)
                    {
                        a = skladowaR;
                    }
                    else
                    {
                        a = skladowaR / suma;
                    }

                    if (suma == 0)
                    {
                        b = skladowaG;
                    }
                    else
                    {
                        b = skladowaG / suma;
                    }

                    if (suma == 0)
                    {
                        c = skladowaB;
                    }
                    else
                    {
                        c = skladowaB / suma;
                    }

                    if (a < 0)
                    {
                        a = 0;
                    }
                    if (a > 255)
                    {
                        a = 255;
                    }
                    if (b < 0)
                    {
                        b = 0;
                    }
                    if (b > 255)
                    {
                        b = 255;
                    }
                    if (c < 0)
                    {
                        c = 0;
                    }
                    if (c > 255)
                    {
                        c = 255;
                    }

                    if ((a != 0 && b != 0) && c != 0)
                    {
                        licznik++;
                    }
                }
            }
            if (licznik < 26000)
            {
                teksturaObiektu = "GŁADKA";
            }
            else
            {
                teksturaObiektu = "CHROPOWATA";
            }
        }

        void UstalNazweObiektu()
        {
            if ((((kolorObiektu == "CZERWONY" || kolorObiektu == "POMARAŃCZOWY") || kolorObiektu == "ZIELONY") && ksztaltObiektu == "OKRĄGŁY") && teksturaObiektu == "GŁADKA")
            {
                nazwaObiektu = "POMIDOR";
            }
            else if (((kolorObiektu == "ZIELONY" && ksztaltObiektu == "PODŁUŻNY") && teksturaObiektu == "CHROPOWATA") || ((kolorObiektu == "ŻÓŁTY" && ksztaltObiektu == "PODŁUŻNY") && teksturaObiektu == "GŁADKA"))
            {
                nazwaObiektu = "CUKINIA";
            }
            else if ((kolorObiektu == "ŻÓŁTY" && ksztaltObiektu == "PODŁUŻNY") && teksturaObiektu == "CHROPOWATA")
            {
                nazwaObiektu = "KUKURYDZA";
            }
            else
            {
                nazwaObiektu = "???";
            }
        }

        void CzyscDane()
        {
            kolorObiektu = "";
            ksztaltObiektu = "";
            wysokoscObiektu = 0;
            szerokoscObiektu = 0;
            teksturaObiektu = "";
            nazwaObiektu = "???";
            xMin = 1000000;
            xMax = 0;
            yMin = 1000000;
            yMax = 0;
        }

        public void RozpoznajObiekt()
        {
            if (pictureBox1.Image != null)
            {
                numericUpDown1.Value = 13;
                numericUpDown1.Value = 0;

                UstalKolorObiektu();
                UstalKsztaltObiektu();
                UstalTekstureObiektu();
                UstalNazweObiektu();

                label8.Text = nazwaObiektu;
                richTextBox1.Text = string.Format("KOLOR:\t\t{0}\nKSZTAŁT:\t{1}\nWYSOKOŚĆ:\t{2}px\nSZEROKOŚĆ:\t{3}px\nTEKSTURA:\t{4}", kolorObiektu, ksztaltObiektu, wysokoscObiektu, szerokoscObiektu, teksturaObiektu);
                CzyscDane();
            }
            postep = 0;
            watek.Abort();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            UruchomWatek(4);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = postep;
            if (progressBar1.Value != 0 && progressBar1.Value != 100)
            {
                postep++;
            }
            else if (progressBar1.Value == 0 && esc == false)
            {
                this.Enabled = true;
            }
        }
    }
}