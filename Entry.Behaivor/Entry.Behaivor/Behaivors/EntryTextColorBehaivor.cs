using System;

namespace Entry.Behaivor.Behaivors
{
    using System.Text.RegularExpressions;
    using Xamarin.Forms;

    public class EntryTextColorBehaivor : Behavior<Entry>
    {
        private string _regex = @"^[0-9]+$";

        #region Bindable Properties 

        public static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EntryTextColorBehaivor), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get
            {
                return (bool)this.GetValue(IsValidProperty);
            }
            set
            {
                this.SetValue(IsValidPropertyKey, value);
            }
        }

        #endregion


        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
            bindable.Focused += Bindable_Focused;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
            bindable.Focused += Bindable_Focused;

        }

        void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry;

            entry = (Entry)sender;

            IsValid = Regex.IsMatch(e.NewTextValue, _regex);

            entry.TextColor = IsValid ? Color.Default : Color.Red;
        }

        void Bindable_Focused(object sender, FocusEventArgs e)
        {
            //TODO: implement the behavior when the entry is focused.
        }
    }
}
