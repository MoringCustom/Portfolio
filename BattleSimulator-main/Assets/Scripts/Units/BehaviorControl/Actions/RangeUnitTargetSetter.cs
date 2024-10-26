using System;

namespace BS.Units.BehaviorControl.Actions
{
    public class RangeUnitTargetSetter : TargetSetter
    {
        private RangeUnit _rangeUnit;

        public override void OnStart()
        {
            _rangeUnit = Soldier as RangeUnit;

            if (_rangeUnit == null)
                throw new ArgumentNullException(nameof(RangeUnit));
        }

        protected override void FindTarget()
        {
            base.FindTarget();
            _rangeUnit.SetTarget(Target);
        }
    }
}