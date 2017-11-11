using System;

namespace Entry.Behaivor.Behaivors
{
    using System.Text.RegularExpressions;
    using Xamarin.Forms;

    public class EntryTextColorBehaivor : Behavior<Entry>
    {
        private string _regex = @"^[0-9]+$";

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
                this.SetValue(IsValidPropertyKey,value);
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
        }

        void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry;

            entry = (Entry)sender;

            IsValid = Regex.IsMatch(e.NewTextValue, _regex);

            entry.TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}
