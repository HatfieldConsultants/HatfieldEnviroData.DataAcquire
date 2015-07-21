﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class RelatedActionMapperBase : ESDATMapperBase<RelatedAction>
    {
        public RelatedActionMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public abstract void SetRelationship(Core.Action action, string relationshipTypeCV, Core.Action action1);

        protected override void Validate(RelatedAction entity)
        {
            Validate(entity.ActionID, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.ActionID)));
            Validate(entity.RelationshipTypeCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.RelationshipTypeCV)));
            Validate(entity.RelatedActionID, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.RelatedActionID)));
            Validate(entity.Action, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.Action)));
            Validate(entity.Action1, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.Action1)));
        }
    }
}
