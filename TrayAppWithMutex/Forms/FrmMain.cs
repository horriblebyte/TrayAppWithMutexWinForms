using System;
using System.Windows.Forms;

using TrayAppWithMutex.Classes;

namespace TrayAppWithMutex.Forms {
    public partial class FrmMain : Form {

        public FrmMain() {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m) {

            if (m.Msg == NativeMethods.WM_SHOWME) {
                //Form üzerindeki WinAPI mesajı WM_SHOWME değerine eşitse formu gösteriyoruz.
                Utils.ShowForm(this);
            }

            if (m.Msg == NativeMethods.WM_SYSCOMMAND) {

                if (m.WParam.ToInt32() == NativeMethods.SC_MINIMIZE) {
                    if (CbSendTrayWhenMinimized.Checked) {
                        //Form üzerindeki WinAPI mesajı WM_SYSCOMMAND, parametresi de SC_MINIMIZE değerine eşitse form kullanıcı tarafından simge durumuna küçültülüyor demektir.
                        //Formun system tray'e taşınmasını sağlayan ComboBox işaretli olduğu için formu simge durumuna küçültme işlemini iptal edip sadece gizliyoruz.
                        Hide();
                        if (CbShowNotifications.Checked) {
                            //Bildirim gösterme seçeneği aktif durumdaysa bildirimi gösteriyoruz.
                            Program.TrayIcon.ShowBalloonTip(500, "Bilgi", "Uygulama, system tray'de çalışmaya devam etmektedir.", ToolTipIcon.Info);
                        }
                        //Simge durumuna küçültme işlemini iptal ediyoruz.
                        m.Result = IntPtr.Zero;
                        return;
                    }
                }

                if (m.WParam.ToInt32() == NativeMethods.SC_CLOSE) {
                    if (CbSendTrayWhenClosed.Checked) {
                        if (WindowState != FormWindowState.Minimized) {
                            //Form üzerindeki WinAPI mesajı WM_SYSCOMMAND, parametresi de SC_CLOSE değerine eşitse form kullanıcı tarafından kapatılıyor demektir.
                            //Formun system tray'e taşınmasını sağlayan ComboBox işaretli olduğu için formu kapatma işlemini iptal edip sadece gizliyoruz.
                            Hide();
                            if (CbShowNotifications.Checked) {
                                //Bildirim gösterme seçeneği aktif durumdaysa bildirimi gösteriyoruz.
                                Program.TrayIcon.ShowBalloonTip(500, "Bilgi", "Uygulama, system tray'de çalışmaya devam etmektedir.", ToolTipIcon.Info);
                            }
                            //Kapatma işlemini iptal ediyoruz.
                            m.Result = IntPtr.Zero;
                            return;
                        }
                    }
                }

            }

            //WinAPI üzerinden forma gelen mesajı işleyen method.
            base.WndProc(ref m);

        }

    }
}