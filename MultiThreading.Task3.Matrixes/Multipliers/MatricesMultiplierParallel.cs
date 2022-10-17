using MultiThreading.Task3.MatrixMultiplier.Matrices;
using System.Threading.Tasks;

namespace MultiThreading.Task3.MatrixMultiplier.Multipliers
{
    public class MatricesMultiplierParallel : IMatricesMultiplier
    {
        public IMatrix Multiply(IMatrix m1, IMatrix m2)
        {
            var resultMatrix = new Matrix(m1.RowCount, m2.ColCount);
            Parallel.For(0, m1.RowCount, i =>
            {
                Parallel.For(byte.MinValue, m2.ColCount, c => {
                    long sum = 0;
                    Parallel.For(byte.MinValue, m1.ColCount, k => {
                        sum += m1.GetElement(i, k) * m2.GetElement(k, c);
                    });

                    resultMatrix.SetElement(i, c, sum);
                });
            });

            return resultMatrix;
        }
    }
}
