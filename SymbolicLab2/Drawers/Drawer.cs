using System.Windows.Forms;

namespace SymbolicLab2.Drawers
{
    class Drawer
    {
        public void Draw(DrawerModel model)
        {
            var form = new PlotForm();
            form.DrawPlot(model);

            Application.Run(form);
        }
    }
}
