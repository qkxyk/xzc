using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xzc.Infrastructure.Query
{
    public class Criterion
    {
        private string _propertyName;
        private object _value;
        private CriteriaOperator _criteriaOperator;
        private ParameterDirection _direction = ParameterDirection.Input;

        public Criterion(string propertyName, object value,
            CriteriaOperator criteriaOperator)
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
        }

        public Criterion(string propertyName, object value,
            CriteriaOperator criteriaOperator, ParameterDirection direction)
        {
            _propertyName = propertyName;
            _value = value;
            _criteriaOperator = criteriaOperator;
            _direction = direction;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public object Value
        {
            get { return _value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return _criteriaOperator; }
        }

        public ParameterDirection Direction
        {
            get { return _direction; }
        }
    }
}
