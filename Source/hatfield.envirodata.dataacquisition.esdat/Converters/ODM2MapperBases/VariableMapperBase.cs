﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class VariableMapperBase : ODM2MapperBase<Variable>, IODM2DuplicableMapper<Variable>
    {
        List<Variable> _backingStore;

        public VariableMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Variable> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(Variable entity)
        {
            Validate(entity.VariableTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.VariableTypeCV)));
            Validate(entity.VariableCode, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.VariableCode)));
            Validate(entity.VariableNameCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.VariableNameCV)));
            Validate(entity.SpeciationCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SpeciationCV)));
            Validate(entity.NoDataValue, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.NoDataValue)));
        }

        public Variable GetDuplicate(WayToHandleNewData wayToHandleNewData, Variable entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Variable>(entity, x =>
                x.VariableCode.Equals(entity.VariableCode),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }
    }
}
