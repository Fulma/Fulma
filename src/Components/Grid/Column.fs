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
            | CustomClass of string
            | Props of IHTMLProp list

        let ofWidth =
            function
            | All, size ->
                match size with
                | IsOneQuarter -> Bulma.Grid.Column.Width.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Width.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Width.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Width.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Width.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Width.Is1
                | Is2 -> Bulma.Grid.Column.Width.Is2
                | Is3 -> Bulma.Grid.Column.Width.Is3
                | Is4 -> Bulma.Grid.Column.Width.Is4
                | Is5 -> Bulma.Grid.Column.Width.Is5
                | Is6 -> Bulma.Grid.Column.Width.Is6
                | Is7 -> Bulma.Grid.Column.Width.Is7
                | Is8 -> Bulma.Grid.Column.Width.Is8
                | Is9 -> Bulma.Grid.Column.Width.Is9
                | Is10 -> Bulma.Grid.Column.Width.Is10
                | Is11 -> Bulma.Grid.Column.Width.Is11
                | IsNarrow -> Bulma.Grid.Column.Width.IsNarrow
                | IsFull -> Bulma.Grid.Column.Width.IsFull
            | Desktop, size ->
                match size with
                | IsOneQuarter -> Bulma.Grid.Column.Desktop.Width.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Desktop.Width.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Desktop.Width.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Desktop.Width.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Desktop.Width.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Desktop.Width.Is1
                | Is2 -> Bulma.Grid.Column.Desktop.Width.Is2
                | Is3 -> Bulma.Grid.Column.Desktop.Width.Is3
                | Is4 -> Bulma.Grid.Column.Desktop.Width.Is4
                | Is5 -> Bulma.Grid.Column.Desktop.Width.Is5
                | Is6 -> Bulma.Grid.Column.Desktop.Width.Is6
                | Is7 -> Bulma.Grid.Column.Desktop.Width.Is7
                | Is8 -> Bulma.Grid.Column.Desktop.Width.Is8
                | Is9 -> Bulma.Grid.Column.Desktop.Width.Is9
                | Is10 -> Bulma.Grid.Column.Desktop.Width.Is10
                | Is11 -> Bulma.Grid.Column.Desktop.Width.Is11
                | IsNarrow -> Bulma.Grid.Column.Desktop.Width.IsNarrow
                | IsFull -> Bulma.Grid.Column.Desktop.Width.IsFull
            | Tablet, size ->
                match size with
                | IsOneQuarter -> Bulma.Grid.Column.Tablet.Width.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Tablet.Width.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Tablet.Width.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Tablet.Width.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Tablet.Width.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Tablet.Width.Is1
                | Is2 -> Bulma.Grid.Column.Tablet.Width.Is2
                | Is3 -> Bulma.Grid.Column.Tablet.Width.Is3
                | Is4 -> Bulma.Grid.Column.Tablet.Width.Is4
                | Is5 -> Bulma.Grid.Column.Tablet.Width.Is5
                | Is6 -> Bulma.Grid.Column.Tablet.Width.Is6
                | Is7 -> Bulma.Grid.Column.Tablet.Width.Is7
                | Is8 -> Bulma.Grid.Column.Tablet.Width.Is8
                | Is9 -> Bulma.Grid.Column.Tablet.Width.Is9
                | Is10 -> Bulma.Grid.Column.Tablet.Width.Is10
                | Is11 -> Bulma.Grid.Column.Tablet.Width.Is11
                | IsNarrow -> Bulma.Grid.Column.Tablet.Width.IsNarrow
                | IsFull -> Bulma.Grid.Column.Tablet.Width.IsFull
            | Mobile, size ->
                match size with
                | IsOneQuarter -> Bulma.Grid.Column.Mobile.Width.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Mobile.Width.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Mobile.Width.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Mobile.Width.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Mobile.Width.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Mobile.Width.Is1
                | Is2 -> Bulma.Grid.Column.Mobile.Width.Is2
                | Is3 -> Bulma.Grid.Column.Mobile.Width.Is3
                | Is4 -> Bulma.Grid.Column.Mobile.Width.Is4
                | Is5 -> Bulma.Grid.Column.Mobile.Width.Is5
                | Is6 -> Bulma.Grid.Column.Mobile.Width.Is6
                | Is7 -> Bulma.Grid.Column.Mobile.Width.Is7
                | Is8 -> Bulma.Grid.Column.Mobile.Width.Is8
                | Is9 -> Bulma.Grid.Column.Mobile.Width.Is9
                | Is10 -> Bulma.Grid.Column.Mobile.Width.Is10
                | Is11 -> Bulma.Grid.Column.Mobile.Width.Is11
                | IsNarrow -> Bulma.Grid.Column.Mobile.Width.IsNarrow
                | IsFull -> Bulma.Grid.Column.Mobile.Width.IsFull
            | WideScreen, size ->
                match size with
                | IsOneQuarter -> Bulma.Grid.Column.WideScreen.Width.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.WideScreen.Width.IsOneThird
                | IsHalf -> Bulma.Grid.Column.WideScreen.Width.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.WideScreen.Width.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.WideScreen.Width.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.WideScreen.Width.Is1
                | Is2 -> Bulma.Grid.Column.WideScreen.Width.Is2
                | Is3 -> Bulma.Grid.Column.WideScreen.Width.Is3
                | Is4 -> Bulma.Grid.Column.WideScreen.Width.Is4
                | Is5 -> Bulma.Grid.Column.WideScreen.Width.Is5
                | Is6 -> Bulma.Grid.Column.WideScreen.Width.Is6
                | Is7 -> Bulma.Grid.Column.WideScreen.Width.Is7
                | Is8 -> Bulma.Grid.Column.WideScreen.Width.Is8
                | Is9 -> Bulma.Grid.Column.WideScreen.Width.Is9
                | Is10 -> Bulma.Grid.Column.WideScreen.Width.Is10
                | Is11 -> Bulma.Grid.Column.WideScreen.Width.Is11
                | IsNarrow -> Bulma.Grid.Column.WideScreen.Width.IsNarrow
                | IsFull -> Bulma.Grid.Column.WideScreen.Width.IsFull

        let ofOffset =
            function
            | All, offset ->
                match offset with
                | IsOneQuarter -> Bulma.Grid.Column.Offset.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Offset.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Offset.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Offset.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Offset.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Offset.Is1
                | Is2 -> Bulma.Grid.Column.Offset.Is2
                | Is3 -> Bulma.Grid.Column.Offset.Is3
                | Is4 -> Bulma.Grid.Column.Offset.Is4
                | Is5 -> Bulma.Grid.Column.Offset.Is5
                | Is6 -> Bulma.Grid.Column.Offset.Is6
                | Is7 -> Bulma.Grid.Column.Offset.Is7
                | Is8 -> Bulma.Grid.Column.Offset.Is8
                | Is9 -> Bulma.Grid.Column.Offset.Is9
                | Is10 -> Bulma.Grid.Column.Offset.Is10
                | Is11 -> Bulma.Grid.Column.Offset.Is11
                | IsNarrow -> Bulma.Grid.Column.Offset.IsNarrow
                | IsFull -> Bulma.Grid.Column.Offset.IsFull
            | Desktop, offset ->
                match offset with
                | IsOneQuarter -> Bulma.Grid.Column.Desktop.Offset.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Desktop.Offset.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Desktop.Offset.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Desktop.Offset.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Desktop.Offset.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Desktop.Offset.Is1
                | Is2 -> Bulma.Grid.Column.Desktop.Offset.Is2
                | Is3 -> Bulma.Grid.Column.Desktop.Offset.Is3
                | Is4 -> Bulma.Grid.Column.Desktop.Offset.Is4
                | Is5 -> Bulma.Grid.Column.Desktop.Offset.Is5
                | Is6 -> Bulma.Grid.Column.Desktop.Offset.Is6
                | Is7 -> Bulma.Grid.Column.Desktop.Offset.Is7
                | Is8 -> Bulma.Grid.Column.Desktop.Offset.Is8
                | Is9 -> Bulma.Grid.Column.Desktop.Offset.Is9
                | Is10 -> Bulma.Grid.Column.Desktop.Offset.Is10
                | Is11 -> Bulma.Grid.Column.Desktop.Offset.Is11
                | IsNarrow -> Bulma.Grid.Column.Desktop.Offset.IsNarrow
                | IsFull -> Bulma.Grid.Column.Desktop.Offset.IsFull
            | Tablet, offset ->
                match offset with
                | IsOneQuarter -> Bulma.Grid.Column.Tablet.Offset.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Tablet.Offset.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Tablet.Offset.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Tablet.Offset.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Tablet.Offset.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Tablet.Offset.Is1
                | Is2 -> Bulma.Grid.Column.Tablet.Offset.Is2
                | Is3 -> Bulma.Grid.Column.Tablet.Offset.Is3
                | Is4 -> Bulma.Grid.Column.Tablet.Offset.Is4
                | Is5 -> Bulma.Grid.Column.Tablet.Offset.Is5
                | Is6 -> Bulma.Grid.Column.Tablet.Offset.Is6
                | Is7 -> Bulma.Grid.Column.Tablet.Offset.Is7
                | Is8 -> Bulma.Grid.Column.Tablet.Offset.Is8
                | Is9 -> Bulma.Grid.Column.Tablet.Offset.Is9
                | Is10 -> Bulma.Grid.Column.Tablet.Offset.Is10
                | Is11 -> Bulma.Grid.Column.Tablet.Offset.Is11
                | IsNarrow -> Bulma.Grid.Column.Tablet.Offset.IsNarrow
                | IsFull -> Bulma.Grid.Column.Tablet.Offset.IsFull
            | Mobile, offset ->
                match offset with
                | IsOneQuarter -> Bulma.Grid.Column.Mobile.Offset.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.Mobile.Offset.IsOneThird
                | IsHalf -> Bulma.Grid.Column.Mobile.Offset.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.Mobile.Offset.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.Mobile.Offset.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.Mobile.Offset.Is1
                | Is2 -> Bulma.Grid.Column.Mobile.Offset.Is2
                | Is3 -> Bulma.Grid.Column.Mobile.Offset.Is3
                | Is4 -> Bulma.Grid.Column.Mobile.Offset.Is4
                | Is5 -> Bulma.Grid.Column.Mobile.Offset.Is5
                | Is6 -> Bulma.Grid.Column.Mobile.Offset.Is6
                | Is7 -> Bulma.Grid.Column.Mobile.Offset.Is7
                | Is8 -> Bulma.Grid.Column.Mobile.Offset.Is8
                | Is9 -> Bulma.Grid.Column.Mobile.Offset.Is9
                | Is10 -> Bulma.Grid.Column.Mobile.Offset.Is10
                | Is11 -> Bulma.Grid.Column.Mobile.Offset.Is11
                | IsNarrow -> Bulma.Grid.Column.Mobile.Offset.IsNarrow
                | IsFull -> Bulma.Grid.Column.Mobile.Offset.IsFull
            | WideScreen, offset ->
                match offset with
                | IsOneQuarter -> Bulma.Grid.Column.WideScreen.Offset.IsOneQuarter
                | IsOneThird -> Bulma.Grid.Column.WideScreen.Offset.IsOneThird
                | IsHalf -> Bulma.Grid.Column.WideScreen.Offset.IsHalf
                | IsTwoThirds -> Bulma.Grid.Column.WideScreen.Offset.IsTwoThirds
                | IsThreeQuarters -> Bulma.Grid.Column.WideScreen.Offset.IsThreeQuarters
                | Is1 -> Bulma.Grid.Column.WideScreen.Offset.Is1
                | Is2 -> Bulma.Grid.Column.WideScreen.Offset.Is2
                | Is3 -> Bulma.Grid.Column.WideScreen.Offset.Is3
                | Is4 -> Bulma.Grid.Column.WideScreen.Offset.Is4
                | Is5 -> Bulma.Grid.Column.WideScreen.Offset.Is5
                | Is6 -> Bulma.Grid.Column.WideScreen.Offset.Is6
                | Is7 -> Bulma.Grid.Column.WideScreen.Offset.Is7
                | Is8 -> Bulma.Grid.Column.WideScreen.Offset.Is8
                | Is9 -> Bulma.Grid.Column.WideScreen.Offset.Is9
                | Is10 -> Bulma.Grid.Column.WideScreen.Offset.Is10
                | Is11 -> Bulma.Grid.Column.WideScreen.Offset.Is11
                | IsNarrow -> Bulma.Grid.Column.WideScreen.Offset.IsNarrow
                | IsFull -> Bulma.Grid.Column.WideScreen.Offset.IsFull

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
              WideScreenpOffset : string option
              CustomClass : string option
              Props : IHTMLProp list }
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
                  WideScreenpOffset = None
                  CustomClass = None
                  Props = [] }

    open Types


    module Width =

        module Dekstop =
            let isOneQuarter = Width (Desktop, IsOneQuarter)
            let isOneThird = Width (Desktop, IsOneThird)
            let isHalf = Width (Desktop, IsHalf)
            let isTwoThirds = Width (Desktop, IsTwoThirds)
            let isThreeQuarters = Width (Desktop, IsThreeQuarters)
            let is1 = Width (Desktop, Is1)
            let is2 = Width (Desktop, Is2)
            let is3 = Width (Desktop, Is3)
            let is4 = Width (Desktop, Is4)
            let is5 = Width (Desktop, Is5)
            let is6 = Width (Desktop, Is6)
            let is7 = Width (Desktop, Is7)
            let is8 = Width (Desktop, Is8)
            let is9 = Width (Desktop, Is9)
            let is10 = Width (Desktop, Is10)
            let is11 = Width (Desktop, Is11)
            let isNarrow = Width (Desktop, IsNarrow)
            let isFull = Width (Desktop, IsFull)

        module WideScreen =
            let isOneQuarter = Width (WideScreen, IsOneQuarter)
            let isOneThird = Width (WideScreen, IsOneThird)
            let isHalf = Width (WideScreen, IsHalf)
            let isTwoThirds = Width (WideScreen, IsTwoThirds)
            let isThreeQuarters = Width (WideScreen, IsThreeQuarters)
            let is1 = Width (WideScreen, Is1)
            let is2 = Width (WideScreen, Is2)
            let is3 = Width (WideScreen, Is3)
            let is4 = Width (WideScreen, Is4)
            let is5 = Width (WideScreen, Is5)
            let is6 = Width (WideScreen, Is6)
            let is7 = Width (WideScreen, Is7)
            let is8 = Width (WideScreen, Is8)
            let is9 = Width (WideScreen, Is9)
            let is10 = Width (WideScreen, Is10)
            let is11 = Width (WideScreen, Is11)
            let isNarrow = Width (WideScreen, IsNarrow)
            let isFull = Width (WideScreen, IsFull)

        module Mobile =
            let isOneQuarter = Width (Mobile, IsOneQuarter)
            let isOneThird = Width (Mobile, IsOneThird)
            let isHalf = Width (Mobile, IsHalf)
            let isTwoThirds = Width (Mobile, IsTwoThirds)
            let isThreeQuarters = Width (Mobile, IsThreeQuarters)
            let is1 = Width (Mobile, Is1)
            let is2 = Width (Mobile, Is2)
            let is3 = Width (Mobile, Is3)
            let is4 = Width (Mobile, Is4)
            let is5 = Width (Mobile, Is5)
            let is6 = Width (Mobile, Is6)
            let is7 = Width (Mobile, Is7)
            let is8 = Width (Mobile, Is8)
            let is9 = Width (Mobile, Is9)
            let is10 = Width (Mobile, Is10)
            let is11 = Width (Mobile, Is11)
            let isNarrow = Width (Mobile, IsNarrow)
            let isFull = Width (Mobile, IsFull)

        module Tablet =
            let isOneQuarter = Width (Tablet, IsOneQuarter)
            let isOneThird = Width (Tablet, IsOneThird)
            let isHalf = Width (Tablet, IsHalf)
            let isTwoThirds = Width (Tablet, IsTwoThirds)
            let isThreeQuarters = Width (Tablet, IsThreeQuarters)
            let is1 = Width (Tablet, Is1)
            let is2 = Width (Tablet, Is2)
            let is3 = Width (Tablet, Is3)
            let is4 = Width (Tablet, Is4)
            let is5 = Width (Tablet, Is5)
            let is6 = Width (Tablet, Is6)
            let is7 = Width (Tablet, Is7)
            let is8 = Width (Tablet, Is8)
            let is9 = Width (Tablet, Is9)
            let is10 = Width (Tablet, Is10)
            let is11 = Width (Tablet, Is11)
            let isNarrow = Width (Tablet, IsNarrow)
            let isFull = Width (Tablet, IsFull)

        let isOneQuarter = Width (All, IsOneQuarter)
        let isOneThird = Width (All, IsOneThird)
        let isHalf = Width (All, IsHalf)
        let isTwoThirds = Width (All, IsTwoThirds)
        let isThreeQuarters = Width (All, IsThreeQuarters)
        let is1 = Width (All, Is1)
        let is2 = Width (All, Is2)
        let is3 = Width (All, Is3)
        let is4 = Width (All, Is4)
        let is5 = Width (All, Is5)
        let is6 = Width (All, Is6)
        let is7 = Width (All, Is7)
        let is8 = Width (All, Is8)
        let is9 = Width (All, Is9)
        let is10 = Width (All, Is10)
        let is11 = Width (All, Is11)
        let isNarrow = Width (All, IsNarrow)
        let isFull = Width (All, IsFull)

    module Offset =

        module Dekstop =
            let isOneQuarter = Offset (Desktop, IsOneQuarter)
            let isOneThird = Offset (Desktop, IsOneThird)
            let isHalf = Offset (Desktop, IsHalf)
            let isTwoThirds = Offset (Desktop, IsTwoThirds)
            let isThreeQuarters = Offset (Desktop, IsThreeQuarters)
            let is1 = Offset (Desktop, Is1)
            let is2 = Offset (Desktop, Is2)
            let is3 = Offset (Desktop, Is3)
            let is4 = Offset (Desktop, Is4)
            let is5 = Offset (Desktop, Is5)
            let is6 = Offset (Desktop, Is6)
            let is7 = Offset (Desktop, Is7)
            let is8 = Offset (Desktop, Is8)
            let is9 = Offset (Desktop, Is9)
            let is10 = Offset (Desktop, Is10)
            let is11 = Offset (Desktop, Is11)
            let isNarrow = Offset (Desktop, IsNarrow)
            let isFull = Offset (Desktop, IsFull)

        module WideScreen =
            let isOneQuarter = Offset (WideScreen, IsOneQuarter)
            let isOneThird = Offset (WideScreen, IsOneThird)
            let isHalf = Offset (WideScreen, IsHalf)
            let isTwoThirds = Offset (WideScreen, IsTwoThirds)
            let isThreeQuarters = Offset (WideScreen, IsThreeQuarters)
            let is1 = Offset (WideScreen, Is1)
            let is2 = Offset (WideScreen, Is2)
            let is3 = Offset (WideScreen, Is3)
            let is4 = Offset (WideScreen, Is4)
            let is5 = Offset (WideScreen, Is5)
            let is6 = Offset (WideScreen, Is6)
            let is7 = Offset (WideScreen, Is7)
            let is8 = Offset (WideScreen, Is8)
            let is9 = Offset (WideScreen, Is9)
            let is10 = Offset (WideScreen, Is10)
            let is11 = Offset (WideScreen, Is11)
            let isNarrow = Offset (WideScreen, IsNarrow)
            let isFull = Offset (WideScreen, IsFull)

        module Mobile =
            let isOneQuarter = Offset (Mobile, IsOneQuarter)
            let isOneThird = Offset (Mobile, IsOneThird)
            let isHalf = Offset (Mobile, IsHalf)
            let isTwoThirds = Offset (Mobile, IsTwoThirds)
            let isThreeQuarters = Offset (Mobile, IsThreeQuarters)
            let is1 = Offset (Mobile, Is1)
            let is2 = Offset (Mobile, Is2)
            let is3 = Offset (Mobile, Is3)
            let is4 = Offset (Mobile, Is4)
            let is5 = Offset (Mobile, Is5)
            let is6 = Offset (Mobile, Is6)
            let is7 = Offset (Mobile, Is7)
            let is8 = Offset (Mobile, Is8)
            let is9 = Offset (Mobile, Is9)
            let is10 = Offset (Mobile, Is10)
            let is11 = Offset (Mobile, Is11)
            let isNarrow = Offset (Mobile, IsNarrow)
            let isFull = Offset (Mobile, IsFull)

        module Tablet =
            let isOneQuarter = Offset (Tablet, IsOneQuarter)
            let isOneThird = Offset (Tablet, IsOneThird)
            let isHalf = Offset (Tablet, IsHalf)
            let isTwoThirds = Offset (Tablet, IsTwoThirds)
            let isThreeQuarters = Offset (Tablet, IsThreeQuarters)
            let is1 = Offset (Tablet, Is1)
            let is2 = Offset (Tablet, Is2)
            let is3 = Offset (Tablet, Is3)
            let is4 = Offset (Tablet, Is4)
            let is5 = Offset (Tablet, Is5)
            let is6 = Offset (Tablet, Is6)
            let is7 = Offset (Tablet, Is7)
            let is8 = Offset (Tablet, Is8)
            let is9 = Offset (Tablet, Is9)
            let is10 = Offset (Tablet, Is10)
            let is11 = Offset (Tablet, Is11)
            let isNarrow = Offset (Tablet, IsNarrow)
            let isFull = Offset (Tablet, IsFull)

        let isOneQuarter = Offset (All, IsOneQuarter)
        let isOneThird = Offset (All, IsOneThird)
        let isHalf = Offset (All, IsHalf)
        let isTwoThirds = Offset (All, IsTwoThirds)
        let isThreeQuarters = Offset (All, IsThreeQuarters)
        let is1 = Offset (All, Is1)
        let is2 = Offset (All, Is2)
        let is3 = Offset (All, Is3)
        let is4 = Offset (All, Is4)
        let is5 = Offset (All, Is5)
        let is6 = Offset (All, Is6)
        let is7 = Offset (All, Is7)
        let is8 = Offset (All, Is8)
        let is9 = Offset (All, Is9)
        let is10 = Offset (All, Is10)
        let is11 = Offset (All, Is11)
        let isNarrow = Offset (All, IsNarrow)
        let isFull = Offset (All, IsFull)

    // Extra
    let customClass = CustomClass
    let props = Props

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
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | x -> failwithf "Error when parsing column option %A" x


        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield ClassName ( Helpers.generateClassName Bulma.Grid.Column.Container
                                                    [ opts.Width
                                                      opts.Offset
                                                      opts.DesktopWidth
                                                      opts.DesktopOffset
                                                      opts.MobileWidth
                                                      opts.MobileOffset
                                                      opts.TabletpWidth
                                                      opts.TabletpOffset
                                                      opts.WideScreenpWidth
                                                      opts.WideScreenpOffset
                                                      opts.CustomClass ] ) :> IHTMLProp
              yield! opts.Props ]
            children
