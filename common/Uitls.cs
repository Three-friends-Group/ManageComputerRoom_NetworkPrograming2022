
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace common
{


    public static class Uitls
    {
        public static int GetTextHeight(Label lblMsg)
        {
            using (Graphics g = lblMsg.CreateGraphics())
            {
                SizeF size = g.MeasureString(lblMsg.Text, lblMsg.Font, 495);
                return (int)Math.Ceiling(size.Height);
            }
        }



        public static void AddIncomming(string message, Panel pnContainer)
        {
            var bubble = new ChatItems.Incomming(message);
            pnContainer.Controls.Add(bubble);
            bubble.BringToFront();
            bubble.Dock = DockStyle.Top;
            int change = pnContainer.VerticalScroll.Maximum;
            pnContainer.AutoScrollPosition = new Point(0, change);
        }

        public static void AddOutGoing(string message, Panel pnContainer)
        {
            var bubble = new ChatItems.Outgoing(message);
            pnContainer.Controls.Add(bubble);
            bubble.BringToFront();
            bubble.Dock = DockStyle.Top;
            int change = pnContainer.VerticalScroll.Maximum;
            pnContainer.AutoScrollPosition = new Point(0, change);
        }



        public static int SetTimeDelay(string timeStr)
        {
            Console.WriteLine(timeStr);

            switch (timeStr)
            {
                case "Now":
                    return 0;
                case "1 minutes later":
                    return 60;

                case "3 minutes later":
                    return 3*60;

                case "5 minutes later":
                    return 5*60;
                case "10 minutes later":
                    return 10 * 60;
                default:
                    return 0 * 60;
            }

        }
    }
}
