namespace CalculateAreaClassLibrary
{
	public static class Utils
	{
		public static void Swap<T>(ref T a, ref T b)
		{
            (b, a) = (a, b);
        }
    }
}
