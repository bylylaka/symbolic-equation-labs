using SymbolicLab2.Drawers;

namespace SymbolicLab2.DrowerDataInitializers
{
    interface IDrowerDataInitializer
    {
        DrawerModel GetDrawerData(Factor factors, double start, double end, double step);
    }
}
