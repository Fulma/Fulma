namespace Elmish.Bulma.Components.Grids

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Column =

    module Types =

        type ISize =
            | IsOneQuarter
            | IsOneThird
            | IsHalf
            | IsTwoThirds
            | IsThreeQuarters
            | Is1
            | Is2
            | Is3
            | Is4
            | Is5
            | Is6
            | Is7
            | Is8
            | Is9
            | Is10
            | Is11
            | IsNarrow
            | IsFull

        type IScreen =
            | All
            | Desktop
            | Tablet
            | Mobile
            | WideScreen

        type Option =
            | Width of IScreen * ISize
            | Offset of IScreen * ISize

        let ofWidth =
            function
            | All, size ->
                match size with
                | IsOneQuarter -> bulma.Grid.Column.Width.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Width.IsOneThird
                | IsHalf -> bulma.Grid.Column.Width.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Width.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Width.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Width.Is1
                | Is2 -> bulma.Grid.Column.Width.Is2
                | Is3 -> bulma.Grid.Column.Width.Is3
                | Is4 -> bulma.Grid.Column.Width.Is4
                | Is5 -> bulma.Grid.Column.Width.Is5
                | Is6 -> bulma.Grid.Column.Width.Is6
                | Is7 -> bulma.Grid.Column.Width.Is7
                | Is8 -> bulma.Grid.Column.Width.Is8
                | Is9 -> bulma.Grid.Column.Width.Is9
                | Is10 -> bulma.Grid.Column.Width.Is10
                | Is11 -> bulma.Grid.Column.Width.Is11
                | IsNarrow -> bulma.Grid.Column.Width.IsNarrow
                | IsFull -> bulma.Grid.Column.Width.IsFull
            | Desktop, size ->
                match size with
                | IsOneQuarter -> bulma.Grid.Column.Desktop.Width.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Desktop.Width.IsOneThird
                | IsHalf -> bulma.Grid.Column.Desktop.Width.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Desktop.Width.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Desktop.Width.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Desktop.Width.Is1
                | Is2 -> bulma.Grid.Column.Desktop.Width.Is2
                | Is3 -> bulma.Grid.Column.Desktop.Width.Is3
                | Is4 -> bulma.Grid.Column.Desktop.Width.Is4
                | Is5 -> bulma.Grid.Column.Desktop.Width.Is5
                | Is6 -> bulma.Grid.Column.Desktop.Width.Is6
                | Is7 -> bulma.Grid.Column.Desktop.Width.Is7
                | Is8 -> bulma.Grid.Column.Desktop.Width.Is8
                | Is9 -> bulma.Grid.Column.Desktop.Width.Is9
                | Is10 -> bulma.Grid.Column.Desktop.Width.Is10
                | Is11 -> bulma.Grid.Column.Desktop.Width.Is11
                | IsNarrow -> bulma.Grid.Column.Desktop.Width.IsNarrow
                | IsFull -> bulma.Grid.Column.Desktop.Width.IsFull
            | Tablet, size ->
                match size with
                | IsOneQuarter -> bulma.Grid.Column.Tablet.Width.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Tablet.Width.IsOneThird
                | IsHalf -> bulma.Grid.Column.Tablet.Width.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Tablet.Width.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Tablet.Width.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Tablet.Width.Is1
                | Is2 -> bulma.Grid.Column.Tablet.Width.Is2
                | Is3 -> bulma.Grid.Column.Tablet.Width.Is3
                | Is4 -> bulma.Grid.Column.Tablet.Width.Is4
                | Is5 -> bulma.Grid.Column.Tablet.Width.Is5
                | Is6 -> bulma.Grid.Column.Tablet.Width.Is6
                | Is7 -> bulma.Grid.Column.Tablet.Width.Is7
                | Is8 -> bulma.Grid.Column.Tablet.Width.Is8
                | Is9 -> bulma.Grid.Column.Tablet.Width.Is9
                | Is10 -> bulma.Grid.Column.Tablet.Width.Is10
                | Is11 -> bulma.Grid.Column.Tablet.Width.Is11
                | IsNarrow -> bulma.Grid.Column.Tablet.Width.IsNarrow
                | IsFull -> bulma.Grid.Column.Tablet.Width.IsFull
            | Mobile, size ->
                match size with
                | IsOneQuarter -> bulma.Grid.Column.Mobile.Width.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Mobile.Width.IsOneThird
                | IsHalf -> bulma.Grid.Column.Mobile.Width.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Mobile.Width.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Mobile.Width.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Mobile.Width.Is1
                | Is2 -> bulma.Grid.Column.Mobile.Width.Is2
                | Is3 -> bulma.Grid.Column.Mobile.Width.Is3
                | Is4 -> bulma.Grid.Column.Mobile.Width.Is4
                | Is5 -> bulma.Grid.Column.Mobile.Width.Is5
                | Is6 -> bulma.Grid.Column.Mobile.Width.Is6
                | Is7 -> bulma.Grid.Column.Mobile.Width.Is7
                | Is8 -> bulma.Grid.Column.Mobile.Width.Is8
                | Is9 -> bulma.Grid.Column.Mobile.Width.Is9
                | Is10 -> bulma.Grid.Column.Mobile.Width.Is10
                | Is11 -> bulma.Grid.Column.Mobile.Width.Is11
                | IsNarrow -> bulma.Grid.Column.Mobile.Width.IsNarrow
                | IsFull -> bulma.Grid.Column.Mobile.Width.IsFull
            | WideScreen, size ->
                match size with
                | IsOneQuarter -> bulma.Grid.Column.WideScreen.Width.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.WideScreen.Width.IsOneThird
                | IsHalf -> bulma.Grid.Column.WideScreen.Width.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.WideScreen.Width.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.WideScreen.Width.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.WideScreen.Width.Is1
                | Is2 -> bulma.Grid.Column.WideScreen.Width.Is2
                | Is3 -> bulma.Grid.Column.WideScreen.Width.Is3
                | Is4 -> bulma.Grid.Column.WideScreen.Width.Is4
                | Is5 -> bulma.Grid.Column.WideScreen.Width.Is5
                | Is6 -> bulma.Grid.Column.WideScreen.Width.Is6
                | Is7 -> bulma.Grid.Column.WideScreen.Width.Is7
                | Is8 -> bulma.Grid.Column.WideScreen.Width.Is8
                | Is9 -> bulma.Grid.Column.WideScreen.Width.Is9
                | Is10 -> bulma.Grid.Column.WideScreen.Width.Is10
                | Is11 -> bulma.Grid.Column.WideScreen.Width.Is11
                | IsNarrow -> bulma.Grid.Column.WideScreen.Width.IsNarrow
                | IsFull -> bulma.Grid.Column.WideScreen.Width.IsFull

        let ofOffset =
            function
            | All, offset ->
                match offset with
                | IsOneQuarter -> bulma.Grid.Column.Offset.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Offset.IsOneThird
                | IsHalf -> bulma.Grid.Column.Offset.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Offset.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Offset.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Offset.Is1
                | Is2 -> bulma.Grid.Column.Offset.Is2
                | Is3 -> bulma.Grid.Column.Offset.Is3
                | Is4 -> bulma.Grid.Column.Offset.Is4
                | Is5 -> bulma.Grid.Column.Offset.Is5
                | Is6 -> bulma.Grid.Column.Offset.Is6
                | Is7 -> bulma.Grid.Column.Offset.Is7
                | Is8 -> bulma.Grid.Column.Offset.Is8
                | Is9 -> bulma.Grid.Column.Offset.Is9
                | Is10 -> bulma.Grid.Column.Offset.Is10
                | Is11 -> bulma.Grid.Column.Offset.Is11
                | IsNarrow -> bulma.Grid.Column.Offset.IsNarrow
                | IsFull -> bulma.Grid.Column.Offset.IsFull
            | Desktop, offset ->
                match offset with
                | IsOneQuarter -> bulma.Grid.Column.Desktop.Offset.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Desktop.Offset.IsOneThird
                | IsHalf -> bulma.Grid.Column.Desktop.Offset.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Desktop.Offset.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Desktop.Offset.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Desktop.Offset.Is1
                | Is2 -> bulma.Grid.Column.Desktop.Offset.Is2
                | Is3 -> bulma.Grid.Column.Desktop.Offset.Is3
                | Is4 -> bulma.Grid.Column.Desktop.Offset.Is4
                | Is5 -> bulma.Grid.Column.Desktop.Offset.Is5
                | Is6 -> bulma.Grid.Column.Desktop.Offset.Is6
                | Is7 -> bulma.Grid.Column.Desktop.Offset.Is7
                | Is8 -> bulma.Grid.Column.Desktop.Offset.Is8
                | Is9 -> bulma.Grid.Column.Desktop.Offset.Is9
                | Is10 -> bulma.Grid.Column.Desktop.Offset.Is10
                | Is11 -> bulma.Grid.Column.Desktop.Offset.Is11
                | IsNarrow -> bulma.Grid.Column.Desktop.Offset.IsNarrow
                | IsFull -> bulma.Grid.Column.Desktop.Offset.IsFull
            | Tablet, offset ->
                match offset with
                | IsOneQuarter -> bulma.Grid.Column.Tablet.Offset.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Tablet.Offset.IsOneThird
                | IsHalf -> bulma.Grid.Column.Tablet.Offset.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Tablet.Offset.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Tablet.Offset.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Tablet.Offset.Is1
                | Is2 -> bulma.Grid.Column.Tablet.Offset.Is2
                | Is3 -> bulma.Grid.Column.Tablet.Offset.Is3
                | Is4 -> bulma.Grid.Column.Tablet.Offset.Is4
                | Is5 -> bulma.Grid.Column.Tablet.Offset.Is5
                | Is6 -> bulma.Grid.Column.Tablet.Offset.Is6
                | Is7 -> bulma.Grid.Column.Tablet.Offset.Is7
                | Is8 -> bulma.Grid.Column.Tablet.Offset.Is8
                | Is9 -> bulma.Grid.Column.Tablet.Offset.Is9
                | Is10 -> bulma.Grid.Column.Tablet.Offset.Is10
                | Is11 -> bulma.Grid.Column.Tablet.Offset.Is11
                | IsNarrow -> bulma.Grid.Column.Tablet.Offset.IsNarrow
                | IsFull -> bulma.Grid.Column.Tablet.Offset.IsFull
            | Mobile, offset ->
                match offset with
                | IsOneQuarter -> bulma.Grid.Column.Mobile.Offset.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.Mobile.Offset.IsOneThird
                | IsHalf -> bulma.Grid.Column.Mobile.Offset.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.Mobile.Offset.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.Mobile.Offset.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.Mobile.Offset.Is1
                | Is2 -> bulma.Grid.Column.Mobile.Offset.Is2
                | Is3 -> bulma.Grid.Column.Mobile.Offset.Is3
                | Is4 -> bulma.Grid.Column.Mobile.Offset.Is4
                | Is5 -> bulma.Grid.Column.Mobile.Offset.Is5
                | Is6 -> bulma.Grid.Column.Mobile.Offset.Is6
                | Is7 -> bulma.Grid.Column.Mobile.Offset.Is7
                | Is8 -> bulma.Grid.Column.Mobile.Offset.Is8
                | Is9 -> bulma.Grid.Column.Mobile.Offset.Is9
                | Is10 -> bulma.Grid.Column.Mobile.Offset.Is10
                | Is11 -> bulma.Grid.Column.Mobile.Offset.Is11
                | IsNarrow -> bulma.Grid.Column.Mobile.Offset.IsNarrow
                | IsFull -> bulma.Grid.Column.Mobile.Offset.IsFull
            | WideScreen, offset ->
                match offset with
                | IsOneQuarter -> bulma.Grid.Column.WideScreen.Offset.IsOneQuarter
                | IsOneThird -> bulma.Grid.Column.WideScreen.Offset.IsOneThird
                | IsHalf -> bulma.Grid.Column.WideScreen.Offset.IsHalf
                | IsTwoThirds -> bulma.Grid.Column.WideScreen.Offset.IsTwoThirds
                | IsThreeQuarters -> bulma.Grid.Column.WideScreen.Offset.IsThreeQuarters
                | Is1 -> bulma.Grid.Column.WideScreen.Offset.Is1
                | Is2 -> bulma.Grid.Column.WideScreen.Offset.Is2
                | Is3 -> bulma.Grid.Column.WideScreen.Offset.Is3
                | Is4 -> bulma.Grid.Column.WideScreen.Offset.Is4
                | Is5 -> bulma.Grid.Column.WideScreen.Offset.Is5
                | Is6 -> bulma.Grid.Column.WideScreen.Offset.Is6
                | Is7 -> bulma.Grid.Column.WideScreen.Offset.Is7
                | Is8 -> bulma.Grid.Column.WideScreen.Offset.Is8
                | Is9 -> bulma.Grid.Column.WideScreen.Offset.Is9
                | Is10 -> bulma.Grid.Column.WideScreen.Offset.Is10
                | Is11 -> bulma.Grid.Column.WideScreen.Offset.Is11
                | IsNarrow -> bulma.Grid.Column.WideScreen.Offset.IsNarrow
                | IsFull -> bulma.Grid.Column.WideScreen.Offset.IsFull

        type Options =
            { Width : string option
              Offset : string option
              DesktopWidth : string option
              DesktopOffset : string option
              TabletpWidth : string option
              TabletpOffset : string option
              MobileWidth : string option
              MobileOffset : string option
              WideScreenpWidth : string option
              WideScreenpOffset : string option }
            static member Empty =
                { Width = None
                  Offset = None
                  DesktopWidth = None
                  DesktopOffset = None
                  TabletpWidth = None
                  TabletpOffset = None
                  MobileWidth = None
                  MobileOffset = None
                  WideScreenpWidth = None
                  WideScreenpOffset = None }

    open Types

    let column (options : Option list) children =
        let parseOptions (result: Options) =
            function
            | Width (screen, width) when screen = All ->
                { result with Width = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = All ->
                { result with Offset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Desktop ->
                { result with DesktopWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Desktop ->
                { result with DesktopOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Tablet ->
                { result with TabletpWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Tablet ->
                { result with TabletpOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = Mobile ->
                { result with MobileWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = Mobile ->
                { result with MobileOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = WideScreen ->
                { result with WideScreenpWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = WideScreen ->
                { result with WideScreenpOffset = ofOffset (screen, offset) |> Some }
            | x -> failwithf "Error when parsing column option %A" x


        let opts = options |> List.fold parseOptions Options.Empty

        div [ ClassName ( Helpers.generateClassName bulma.Grid.Columns.Container
                                                    [ opts.Width
                                                      opts.Offset
                                                      opts.DesktopWidth
                                                      opts.DesktopOffset
                                                      opts.MobileWidth
                                                      opts.MobileOffset
                                                      opts.TabletpWidth
                                                      opts.TabletpOffset
                                                      opts.WideScreenpWidth
                                                      opts.WideScreenpOffset ] ) ]
            [ children ]
