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
        
        // Update borders
        var contentBorders = this.GetVisualDescendants().OfType<Border>()
            .Where(b => b.Name != null && (b.Name == "headerBorder" || b.Name == "contentBorder" || b.Name.EndsWith("Border")));
            
        if (!contentBorders.Any())
        {
            contentBorders = this.GetVisualDescendants().OfType<Border>()
                .Where(b => b.BorderThickness.Top > 0 && b.IsVisible);
        }
        
        foreach (var border in contentBorders)
        {
            border.Background = Brushes.Gold;
            border.BorderBrush = Brushes.DarkSlateBlue;
        }
        
        // Update buttons
        UpdateButtonsForLightTheme();
        
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
        
        // Update borders
        var contentBorders = this.GetVisualDescendants().OfType<Border>()
            .Where(b => b.Name != null && (b.Name == "headerBorder" || b.Name == "contentBorder" || b.Name.EndsWith("Border")));
            
        if (!contentBorders.Any())
        {
            contentBorders = this.GetVisualDescendants().OfType<Border>()
                .Where(b => b.BorderThickness.Top > 0 && b.IsVisible);
        }
        
        foreach (var border in contentBorders)
        {
            border.Background = Brushes.DarkSlateBlue;
            border.BorderBrush = Brushes.Yellow;
        }
        
        // Update buttons
        UpdateButtonsForDarkTheme();
        
        // Update Menu items
        UpdateMenuItemsForDarkTheme();
    }
    
    private void UpdateButtonsForLightTheme()
    {
        // Find all buttons in the visual tree
        var buttons = this.GetVisualDescendants().OfType<Button>();
        
        foreach (var button in buttons)
        {
            // Check if this is a bronButton (by examining Classes)
            if (button.Classes.Contains("bronButton"))
            {
                // Light theme version of bronButton
                bronButton.Background = Brushes.DarkSlateBlue;
                bronButton.Foreground = Brushes.Gold;
                
                // Optional: You can also modify hover state effects by updating the style
                // This would require more complex code to modify the style resources
            }
            else
            {
                // Default button styling for other buttons
                button.Background = Brushes.White;
                button.Foreground = Brushes.Black;
            }
        }
    }
    
    private void UpdateButtonsForDarkTheme()
    {
        // Find all buttons in the visual tree
        var buttons = this.GetVisualDescendants().OfType<Button>();
        
        foreach (var button in buttons)
        {
            // Check if this is a bronButton (by examining Classes)
            if (button.Classes.Contains("bronButton"))
            {
                // Dark theme version of bronButton - restore original styling
                bronButton.Background = Brushes.Gold;
                bronButton.Foreground = Brushes.DarkSlateBlue;
            }
            else
            {
                // Default button styling for other buttons
                button.Background = Brushes.DarkSlateBlue;
                button.Foreground = Brushes.Gold;
            }
        }
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