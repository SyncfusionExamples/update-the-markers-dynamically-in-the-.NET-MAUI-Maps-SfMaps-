using Syncfusion.Maui.Maps;

namespace MapMarkerUpdate
{
    public class MapsBehavior : Behavior<ContentPage>
    {
        private Button AddButton;
        private Button UpdateButton;
        private Button RemoveButton;
        private Button ClearButton;
        private MapMarkerCollection MarkerCollection;
        private MapMarker mapMarker;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.AddButton = bindable.FindByName<Button>("AddButton");
            this.AddButton.Clicked += AddButton_Clicked;

            this.UpdateButton = bindable.FindByName<Button>("UpdateButton");
            this.UpdateButton.Clicked += UpdateButton_Clicked;

            this.RemoveButton = bindable.FindByName<Button>("RemoveButton");
            this.RemoveButton.Clicked += RemoveButton_Clicked;

            this.ClearButton = bindable.FindByName<Button>("ClearButton");
            this.ClearButton.Clicked += ClearButton_Clicked;

            this.MarkerCollection = bindable.FindByName<MapMarkerCollection>("MarkerCollection");
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            this.mapMarker = new MapMarker();
            this.mapMarker.Latitude = 20.593684;
            this.mapMarker.Longitude = 78.96288;
            this.mapMarker.IconWidth = 15;
            this.mapMarker.IconHeight = 15;
            this.mapMarker.IconFill = Color.FromRgb(47, 152, 243);

            this.MarkerCollection.Add(mapMarker);
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            this.mapMarker.IconHeight = 15;
            this.mapMarker.IconWidth = 15;
            this.mapMarker.IconType = MapIconType.Square;
            this.mapMarker.IconFill = Colors.Red;
        }

        private void RemoveButton_Clicked(object sender, EventArgs e)
        {
            this.MarkerCollection.Remove(mapMarker);
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            this.MarkerCollection.Clear();
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);

            if (this.AddButton != null)
            {
                this.AddButton.Clicked -= AddButton_Clicked;
            }

            if (this.UpdateButton != null)
            {
                this.UpdateButton.Clicked -= UpdateButton_Clicked;
            }

            if (this.RemoveButton != null)
            {
                this.RemoveButton.Clicked -= RemoveButton_Clicked;
            }

            if (this.ClearButton != null)
            {
                this.ClearButton.Clicked -= ClearButton_Clicked;
            }

            this.AddButton = this.UpdateButton = this.RemoveButton = this.ClearButton = null;
            this.MarkerCollection = null;
        }
    }
}
