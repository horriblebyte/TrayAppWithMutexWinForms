using System;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using TrayAppWithMutex.Forms;
using TrayAppWithMutex.Classes;

namespace TrayAppWithMutex {
    public static class Program {

        //Uygulama çalıştığı müddetçe system tray'de bulunacak olan NotifyIcon'u tanımladık.
        public static NotifyIcon _notifyIcon;

        // AssemblyInfo.cs üzerindeki GUID'i aldık.
        private static string _guid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true).GetValue(0)).Value.ToString();

        //Uygulama için bir mutex tanımladık.
        private static Mutex _mutex = new Mutex(true, _guid);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            if (_mutex.WaitOne(TimeSpan.Zero, true)) {
                //Mutex tespit edilemedi.
                //Dolayısıyla uygulama sıfırdan başlatılıyor.
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //NotifyIcon'un niteliklerini belirliyoruz.
                using (_notifyIcon = new NotifyIcon()) {
                    //NotifyIcon'un üzerinde fare imleci bekletildiğinde görünecek yazıyı (tooltip) tanımladık.
                    _notifyIcon.Text = Application.ProductName;
                    //NotifyIcon'un simgesini tanımladık.
                    _notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);

                    //NotifyIcon'un üzerine çift tıklandığında gerçekleşecek bir event tanımladık.
                    _notifyIcon.DoubleClick += (o, e) => {
                        //NotifyIcon'a çift tıklandı.
                        //Hali hazırda çalışmakta olan uygulama ekrana getiriliyor.
                        Utils.ShowActiveForm();
                    };

                    //NotifyIcon'a sağ tıklandığında açılan menünün elemanları tanımlanıyor.
                    _notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                        new MenuItem("Göster", (s, e) => {
                            //Hali hazırda çalışmakta olan uygulamayı ekrana getirir.
                            Utils.ShowActiveForm();
                        }),
                        new MenuItem("Kapat", (s, e) => {
                            //Uygulamayı kapatır.
                            Utils.ProperExit();
                        }),
                    });

                    //System tray'deki NotifyIcon'umuz görünür duruma getiriliyor.
                    _notifyIcon.Visible = true;

                    //Ana form başlatılıyor.
                    Application.Run(new FrmMain());
                }

            } else {
                //Aynı Mutex tespit edildi.
                //Hali hazırda çalışmakta olan uygulama ekrana getiriliyor.
                Utils.ShowActiveForm();
            }
        }

    }
}