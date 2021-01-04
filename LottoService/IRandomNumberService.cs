namespace LottoService
{
  public interface IRandomNumberService<T>
  {
    /// <summary>Returns a random integer that is within a specified range.</summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The inclusive upper bound of the random number returned.</param>
    /// <typeparam name="T">A type that is a numeric, such as int.</typeparam>
    /// <returns>Returns a random integer that is within the specified range.</returns>
    T Next(T min, T max);
  }
}