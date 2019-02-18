using System.Linq;
using System.Windows.Forms;

namespace SymbolicLab2.Drawers
{
    class Drawer
    {
        public void Draw(DrawerModel[] models)
        {
            var form = new PlotForm();

            models.ToList().ForEach(model =>
            {
                form.DrawPlot(model);
            });
           
            Application.Run(form);
        }
    }
}
