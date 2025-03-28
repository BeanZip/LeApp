using Avalonia.Controls;
using System.Runtime.InteropServices;
using Avalonia.Media;
using System.Linq;
using Avalonia.VisualTree;

namespace LeApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
   
    private bool isDarkTheme = true;
    
    public void ThemeSwitch(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (isDarkTheme)
        {
            // Switch to light theme
            this.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Light;
            isDarkTheme = false;
            theme.Header = "Change to Dark";
            
            // Change panel background
            mainPanel.Background = Brushes.Orange;
            
            // Update controls for light theme
            UpdateControlsForLightTheme();
        }
        else
        {
            // Switch to dark theme
            this.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Dark;
            isDarkTheme = true;
            theme.Header = "Change to Light";
            
            // Change panel background
            mainPanel.Background = Brushes.Purple;
            
            // Update controls for dark theme
            UpdateControlsForDarkTheme();
        }
    }
    
    private void UpdateControlsForLightTheme()
    {
        // Find only visible TextBlocks and update them
        var textBlocks = this.GetVisualDescendants().OfType<TextBlock>()
            .Where(tb => tb.IsVisible);
        foreach (var textBlock in textBlocks)
        {
            textBlock.Foreground = Brushes.DarkSlateBlue;
        }
        
        // Only update specific named borders instead of all borders
        // Or update only visible borders that are part of your content
        var contentBorders = this.GetVisualDescendants().OfType<Border>()
            .Where(b => b.Name != null && (b.Name == "headerBorder" || b.Name == "contentBorder" || b.Name.EndsWith("Border")));
            
        if (!contentBorders.Any())
        {
            // Fallback: if no named borders, try to identify content borders by their properties
            contentBorders = this.GetVisualDescendants().OfType<Border>()
                .Where(b => b.BorderThickness.Top > 0 && b.IsVisible);
        }
        
        foreach (var border in contentBorders)
        {
            border.Background = Brushes.Gold;
            border.BorderBrush = Brushes.DarkSlateBlue;
        }
        
        // Update Menu items
        UpdateMenuItemsForLightTheme();
    }
    
    private void UpdateControlsForDarkTheme()
    {
        // Find only visible TextBlocks and update them
        var textBlocks = this.GetVisualDescendants().OfType<TextBlock>()
            .Where(tb => tb.IsVisible);
        foreach (var textBlock in textBlocks)
        {
            textBlock.Foreground = Brushes.Gold;
        }
        
        // Only update specific named borders instead of all borders
        // Or update only visible borders that are part of your content
        var contentBorders = this.GetVisualDescendants().OfType<Border>()
            .Where(b => b.Name != null && (b.Name == "headerBorder" || b.Name == "contentBorder" || b.Name.EndsWith("Border")));
            
        if (!contentBorders.Any())
        {
            // Fallback: if no named borders, try to identify content borders by their properties
            contentBorders = this.GetVisualDescendants().OfType<Border>()
                .Where(b => b.BorderThickness.Top > 0 && b.IsVisible);
        }
        
        foreach (var border in contentBorders)
        {
            border.Background = Brushes.DarkSlateBlue;
            border.BorderBrush = Brushes.Yellow;
        }
        
        // Update Menu items
        UpdateMenuItemsForDarkTheme();
    }
    
    private void UpdateMenuItemsForLightTheme()
    {
        // Find all MenuItems in the visual tree and update them
        var menuItems = this.GetVisualDescendants().OfType<MenuItem>();
        foreach (var menuItem in menuItems)
        {
            menuItem.Foreground = Brushes.DarkSlateBlue;
            menuItem.Background = Brushes.Gold;
        }
        
        // Update the main menu
        var menu = this.GetVisualDescendants().OfType<Menu>().FirstOrDefault();
        if (menu != null)
        {
            menu.Background = Brushes.Gold;
            menu.BorderBrush = Brushes.DarkSlateBlue;
        }
    }
    
    private void UpdateMenuItemsForDarkTheme()
    {
        // Find all MenuItems in the visual tree and update them
        var menuItems = this.GetVisualDescendants().OfType<MenuItem>();
        foreach (var menuItem in menuItems)
        {
            menuItem.Foreground = Brushes.Gold;
            menuItem.Background = Brushes.DarkSlateBlue;
        }
        
        // Update the main menu
        var menu = this.GetVisualDescendants().OfType<Menu>().FirstOrDefault();
        if (menu != null)
        {
            menu.Background = Brushes.DarkSlateBlue;
            menu.BorderBrush = Brushes.Yellow;
        }
    }
}