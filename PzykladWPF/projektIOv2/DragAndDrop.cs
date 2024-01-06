using System.Windows.Input;
using System.Windows;
using System.Diagnostics;

namespace projektIOv2
{
    /// <summary>
    /// Klasa obsługująca funkcjonalność przeciągania i upuszczania okna.
    /// </summary>
    class DragAndDrop
    {
        private Window window;
        private Point offsetPosition;

        /// <summary>
        /// Konstruktor klasy DragAndDrop.
        /// </summary>
        /// <param name="window">Okno, które ma być obsługiwane funkcjonalnością przeciągania i upuszczania.</param>
        public DragAndDrop(Window window)
        {
            this.window = window;
        }

        /// <summary>
        /// Obsługuje zdarzenie naciśnięcia lewego przycisku myszy.
        /// Zbiera informacje o pozycji kursora i przesunięciu między kursor a lewym górnym rogiem okna.
        /// </summary>
        /// <param name="sender">Obiekt, który wywołuje zdarzenie.</param>
        /// <param name="e">Argumenty zdarzenia naciśnięcia przycisku myszy.</param>
        public void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("DragAndDrop: OnMouseLeftButtonDown");
            Point mousePosition = Mouse.GetPosition(this.window);
            Point cursorPosition = this.window.PointToScreen(mousePosition);
            Point windowPosition = new Point(this.window.Left, this.window.Top);
            offsetPosition = (Point)(cursorPosition - windowPosition);
            Mouse.Capture(this.window, CaptureMode.Element);
        }

        /// <summary>
        /// Obsługuje zdarzenie zwolnienia lewego przycisku myszy.
        /// Zatrzymuje przechwytywanie myszy.
        /// </summary>
        /// <param name="sender">Obiekt, który wywołuje zdarzenie.</param>
        /// <param name="e">Argumenty zdarzenia zwolnienia przycisku myszy.</param>
        public void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Trace.WriteLine("DragAndDrop: OnMouseLeftButtonUp");
            Mouse.Capture(null);
        }

        /// <summary>
        /// Obsługuje zdarzenie ruchu myszy.
        /// Przesuwa okno, jeśli lewy przycisk myszy jest wciśnięty.
        /// </summary>
        /// <param name="sender">Obiekt, który wywołuje zdarzenie.</param>
        /// <param name="e">Argumenty zdarzenia ruchu myszy.</param>
        public void OnMouseMove(object sender, MouseEventArgs e)
        {
            //Trace.WriteLine("DragAndDrop: OnMouseMove");
            if (Mouse.Captured == this.window
                && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                //Trace.WriteLine("DragAndDrop: OnMouseMove: Moving the window provided");
                Point mousePosition = Mouse.GetPosition(this.window);
                Point cursorPosition = this.window.PointToScreen(mousePosition);
                //Point newPosition = new Point (cursorPosition.X - offsetPosition.X, 
                //                               cursorPosition.Y - offsetPosition.Y);
                Point newPosition = (Point)(cursorPosition - offsetPosition);

                this.window.Left = newPosition.X;
                this.window.Top = newPosition.Y;
            }
        }

    }
}
