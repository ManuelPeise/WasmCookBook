using System.Linq.Expressions;

namespace Logic.Shared.Models
{
    public class DbQuery<T> where T : class
    {
        private bool _asNoTracking;
        private Expression<Func<T, bool>>? _whereExpression;
        public bool AsNoTracking { get => _asNoTracking; set { _asNoTracking = value; } }
        public Expression<Func<T, bool>>? WhereExpression { get => _whereExpression; set { _whereExpression = value; } }
    }
}
