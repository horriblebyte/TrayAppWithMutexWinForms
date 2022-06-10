using System;
using System.Windows.Forms;

namespace TrayAppWithMutex.Classes {
    public static class Utils {
        /// <summary>
        /// //Hali hazırda çalışmakta olan formu ekrana getirir.
        /// </summary>
        public static void ShowActiveForm() {
            NativeMethods.PostMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_SHOWME, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// İstenen forma odaklanır ve ekrana getirir.
        /// </summary>
        /// <param name="form">İşlem yapılacak Form nesnesi</param>
        public static void ShowForm(Form form) {
            //Form görünür duruma getiriliyor.
            form.Show();

            if (form.WindowState == FormWindowState.Minimized) {
                //Eğer formun statüsü Minimized (simge durumuna küçültülmüş) ise, Normal olarak belirleniyor.
                form.WindowState = FormWindowState.Normal;
            }

            //Form öne çıkartılıp odaklanılmış duruma getiriliyor.
            form.Activate();
        }

        /// <summary>
        /// Uygulamanın durumuna göre en uygun çıkış yöntemini belirler ve uygular.
        /// </summary>
        public static void ProperExit() {
            if (Application.MessageLoop) {
                Application.Exit();
            } else {
                Environment.Exit(0);
            }
        }

    }
}