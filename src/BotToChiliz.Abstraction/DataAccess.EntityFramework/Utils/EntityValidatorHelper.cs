using System;
using System.Collections.Generic;
using BotToChiliz.Abstraction.Data;
using BotToChiliz.Abstraction.Data.Audited;
using BotToChiliz.Abstraction.DataAccess.EntityFramework.Enumeration;

namespace BotToChiliz.Abstraction.DataAccess.EntityFramework.Utils
{
    public class EntityValidatorHelper
    {
        public static void FullAuditedValidator<T>(FullAuditedBase<T> entity, CheckProgressType progressType)
        {
            CheckBase(entity, progressType);
            CheckFullAuditBase(entity, progressType);
        }
        public static void AuditedValidator<T>(AuditedBase<T> entity, CheckProgressType progressType)
        {
            CheckBase(entity, progressType);
            CheckAuditBase(entity, progressType);
        }
        public static void EntityValidator<T>(EntityBase<T> entity, CheckProgressType progressType)
        {
            CheckBase(entity, progressType);
        }
        public static void CreationAuditedEntityValidator<TEntity,T>(TEntity entity, CheckProgressType progressType)
        where TEntity : EntityBase<T>, ICreationAudited
        {
            CheckBase(entity, progressType);
            if (progressType == CheckProgressType.Create)
                CheckCreationAudited(entity);
        }

        private static void CheckBase<T>(IEntity<T> entity, CheckProgressType progressType)
        {
            if (entity == null)
                throw new ArgumentNullException($"{nameof(entity)} object is not found!");

            if (progressType == CheckProgressType.Create)
                return;

            if (entity.Id.Equals(0))
                throw new KeyNotFoundException($"{nameof(entity.Id)} object is not found! [{nameof(entity.Id)}:{entity.Id}]");
        }

        private static void CheckFullAuditBase(IFullAudited entity, CheckProgressType progressType)
        {
            if (progressType == CheckProgressType.Delete)
                CheckDeletionAudited(entity);
            else
                CheckAuditBase(entity, progressType);
        }
        private static void CheckAuditBase(IAudited entity, CheckProgressType progressType)
        {
            if (progressType == CheckProgressType.Delete)
                return;
            if (progressType == CheckProgressType.Create)
                CheckCreationAudited(entity);
            if (progressType == CheckProgressType.Update)
                CheckModificationAudited(entity);
        }

        private static void CheckCreationAudited(ICreationAudited entity)
        {
            if (string.IsNullOrEmpty(entity.CreatedBy))
                throw new MissingFieldException($"{nameof(entity.CreatedBy)} field is required!",
                    $"[{nameof(entity.CreatedBy)}:{entity.CreatedBy}]");

            if (entity.CreatedBy.Length > Constants.CreatedByMaxLength)
                throw new ArgumentOutOfRangeException($"[{nameof(entity.CreatedBy)}]",
                    $"{nameof(entity.CreatedBy)} field is longer than {Constants.CreatedByMaxLength} characters!");

        }

        private static void CheckModificationAudited(IModificationAudited entity)
        {
            if (string.IsNullOrEmpty(entity.ModifiedBy))
                throw new MissingFieldException($"{nameof(entity.ModifiedBy)} field is required!",
                    $"[{nameof(entity.ModifiedBy)}:{entity.ModifiedBy}]");

            if (entity.ModifiedBy.Length > Constants.ModifiedByMaxLength)
                throw new ArgumentOutOfRangeException($"[{nameof(entity.ModifiedBy)}]",
                    $"{nameof(entity.ModifiedBy)} field is longer than {Constants.ModifiedByMaxLength} characters!");
        }

        private static void CheckDeletionAudited(IDeletionAudited entity)
        {
            if (string.IsNullOrEmpty(entity.DeletedBy))
                throw new MissingFieldException($"{nameof(entity.DeletedBy)} field is required!",
                    $"[{nameof(entity.DeletedBy)}:{entity.DeletedBy}]");

            if (entity.DeletedBy.Length >
                Constants.DeletedByMaxLength)
                throw new ArgumentOutOfRangeException($"[{nameof(entity.DeletedBy)}]",
                    $"{nameof(entity.DeletedBy)} field is longer than {Constants.DeletedByMaxLength} characters!");
        }

    }
}
