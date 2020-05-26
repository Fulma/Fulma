module FulmaExtensions.Timeline

open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Extensions.Wikiki
open Fable.FontAwesome

let defaultLayout () =
    Timeline.timeline []
        [ Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "Start" ] ]
          Timeline.Item.item []
            [ Timeline.Item.marker [] []
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "January 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Item.item []
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsImage; Timeline.Item.Marker.Is32x32 ]
                [ img [ Src "https://bulma.io/images/placeholders/32x32.png" ] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "February 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "2017" ] ]
          Timeline.Item.item []
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsIcon ]
                [ Fa.i [ Fa.Solid.Flag ] [] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "March 2017" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "End" ] ] ]

let colors () =
    Timeline.timeline []
        [ Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "Start" ] ]
          Timeline.Item.item [ Timeline.Item.Color IsPrimary ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.Color IsPrimary ] []
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "January 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Item.item [ Timeline.Item.Color IsWarning ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsImage
                                     Timeline.Item.Marker.Is32x32
                                     Timeline.Item.Marker.Color IsWarning ]
                [ img [ Src "https://bulma.io/images/placeholders/32x32.png" ] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "February 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "2017" ] ]
          Timeline.Item.item [ Timeline.Item.Color IsDanger ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsIcon
                                     Timeline.Item.Marker.Color IsDanger ]
                [ Fa.i [ Fa.Solid.Flag ] [] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "March 2017" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "End" ] ] ]

let centered () =
    Timeline.timeline [ Timeline.IsCentered ]
        [ Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "Start" ] ]
          Timeline.Item.item [ Timeline.Item.Color IsPrimary ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.Color IsPrimary ] []
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "January 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Item.item [ Timeline.Item.Color IsWarning ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsImage
                                     Timeline.Item.Marker.Is32x32
                                     Timeline.Item.Marker.Color IsWarning ]
                [ img [ Src "https://bulma.io/images/placeholders/32x32.png" ] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "February 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "2017" ] ]
          Timeline.Item.item [ Timeline.Item.Color IsDanger ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsIcon
                                     Timeline.Item.Marker.Color IsDanger ]
                [ Fa.i [ Fa.Solid.Flag ] [] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "March 2017" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "End" ] ] ]

let rtl () =
    Timeline.timeline [ Timeline.IsRtl ]
        [ Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "Start" ] ]
          Timeline.Item.item [ Timeline.Item.Color IsPrimary ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.Color IsPrimary ] []
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "January 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Item.item [ Timeline.Item.Color IsWarning ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsImage
                                     Timeline.Item.Marker.Is32x32
                                     Timeline.Item.Marker.Color IsWarning ]
                [ img [ Src "https://bulma.io/images/placeholders/32x32.png" ] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "February 2016" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "2017" ] ]
          Timeline.Item.item [ Timeline.Item.Color IsDanger ]
            [ Timeline.Item.marker [ Timeline.Item.Marker.IsIcon
                                     Timeline.Item.Marker.Color IsDanger ]
                [ Fa.i [ Fa.Solid.Flag ] [] ]
              Timeline.Item.content []
                [ p [ Class "heading" ] [ str "March 2017" ]
                  p [] [ str "Timeline content - Can include any HTML element" ] ] ]
          Timeline.Header.header []
            [ Tag.tag [ Tag.Size IsMedium; Tag.Color IsPrimary ] [ str "End" ] ] ]


let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Timeline

Display a vertical **timeline**, in different colors, sizes, and states.

*[Documentation](https://wikiki.github.io/components/timeline/)*

### Installation

- `paket add Fulma.Extensions.Wikiki.Timeline --project <your project>`
- Follow instructions from `dotnet femto yourProject.fsproj`
                        """
                     Render.docSection
                         "### Default colors and layout"
                         (Widgets.Showcase.view defaultLayout (Render.includeCode __LINE__ __SOURCE_FILE__))

                     Render.docSection
                         "### Custom marker and line colors"
                         (Widgets.Showcase.view colors (Render.includeCode __LINE__ __SOURCE_FILE__))

                     Render.docSection
                         "### Centered layout"
                         (Widgets.Showcase.view centered (Render.includeCode __LINE__ __SOURCE_FILE__))

                     Render.docSection
                         "### Right to left layout"
                         (Widgets.Showcase.view rtl (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
