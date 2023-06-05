using decorator.Common.Interfaces;
using decorator.Common.Models;
using System.Dynamic;
using System.Reflection;

namespace decorator.Decorators.Dynamic
{
    public abstract class DynamicDecoratorBase : DynamicObject, IRepository
    {
        protected dynamic _innerRepository;

        public DynamicDecoratorBase(IRepository repository)
        {
            _innerRepository = repository;
        }

        public string RepositoryInterfaceProperty { get; set; }

        public virtual IList<Person> GetAll()
        {
            return _innerRepository.GetAll();
        }

        public virtual Person Delete(long id)
        {
            return _innerRepository.Delete(id);
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                result = null;
                var info = _innerRepository.GetType().GetMethod(binder.Name);

                if (info != null)
                {
                    result = info.Invoke(_innerRepository, args);
                }
                else
                {
                    if (_innerRepository is DynamicObject)
                    {
                        _innerRepository.TryInvokeMember(binder, args, out result);
                    }
                }
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            try
            {
                var property = _innerRepository.GetType().GetProperty(
                                binder.Name, BindingFlags.Public | BindingFlags.Instance);

                if (property != null && property.CanWrite)
                {
                    property.SetValue(_innerRepository, value, null);
                }
                else
                {
                    if (_innerRepository is DynamicObject)
                    {
                        _innerRepository.TrySetMember(binder, value);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            try
            {
                result = null;
                var property = _innerRepository.GetType().GetProperty(
                                binder.Name, BindingFlags.Public | BindingFlags.Instance);

                if (property != null && property.CanWrite)
                {
                    result = property.GetValue(_innerRepository, null);
                }
                else
                {
                    if (_innerRepository is DynamicObject)
                    {
                        _innerRepository.TryGetMember(binder, out result);
                    }
                }
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
