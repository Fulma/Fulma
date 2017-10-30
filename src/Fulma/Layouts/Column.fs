namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
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
            let inline isOneQuarter<'T> = Width (Desktop, IsOneQuarter)
            let inline isOneThird<'T> = Width (Desktop, IsOneThird)
            let inline isHalf<'T> = Width (Desktop, IsHalf)
            let inline isTwoThirds<'T> = Width (Desktop, IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (Desktop, IsThreeQuarters)
            let inline is1<'T> = Width (Desktop, Is1)
            let inline is2<'T> = Width (Desktop, Is2)
            let inline is3<'T> = Width (Desktop, Is3)
            let inline is4<'T> = Width (Desktop, Is4)
            let inline is5<'T> = Width (Desktop, Is5)
            let inline is6<'T> = Width (Desktop, Is6)
            let inline is7<'T> = Width (Desktop, Is7)
            let inline is8<'T> = Width (Desktop, Is8)
            let inline is9<'T> = Width (Desktop, Is9)
            let inline is10<'T> = Width (Desktop, Is10)
            let inline is11<'T> = Width (Desktop, Is11)
            let inline isNarrow<'T> = Width (Desktop, IsNarrow)
            let inline isFull<'T> = Width (Desktop, IsFull)

        module WideScreen =
            let inline isOneQuarter<'T> = Width (WideScreen, IsOneQuarter)
            let inline isOneThird<'T> = Width (WideScreen, IsOneThird)
            let inline isHalf<'T> = Width (WideScreen, IsHalf)
            let inline isTwoThirds<'T> = Width (WideScreen, IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (WideScreen, IsThreeQuarters)
            let inline is1<'T> = Width (WideScreen, Is1)
            let inline is2<'T> = Width (WideScreen, Is2)
            let inline is3<'T> = Width (WideScreen, Is3)
            let inline is4<'T> = Width (WideScreen, Is4)
            let inline is5<'T> = Width (WideScreen, Is5)
            let inline is6<'T> = Width (WideScreen, Is6)
            let inline is7<'T> = Width (WideScreen, Is7)
            let inline is8<'T> = Width (WideScreen, Is8)
            let inline is9<'T> = Width (WideScreen, Is9)
            let inline is10<'T> = Width (WideScreen, Is10)
            let inline is11<'T> = Width (WideScreen, Is11)
            let inline isNarrow<'T> = Width (WideScreen, IsNarrow)
            let inline isFull<'T> = Width (WideScreen, IsFull)

        module Mobile =
            let inline isOneQuarter<'T> = Width (Mobile, IsOneQuarter)
            let inline isOneThird<'T> = Width (Mobile, IsOneThird)
            let inline isHalf<'T> = Width (Mobile, IsHalf)
            let inline isTwoThirds<'T> = Width (Mobile, IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (Mobile, IsThreeQuarters)
            let inline is1<'T> = Width (Mobile, Is1)
            let inline is2<'T> = Width (Mobile, Is2)
            let inline is3<'T> = Width (Mobile, Is3)
            let inline is4<'T> = Width (Mobile, Is4)
            let inline is5<'T> = Width (Mobile, Is5)
            let inline is6<'T> = Width (Mobile, Is6)
            let inline is7<'T> = Width (Mobile, Is7)
            let inline is8<'T> = Width (Mobile, Is8)
            let inline is9<'T> = Width (Mobile, Is9)
            let inline is10<'T> = Width (Mobile, Is10)
            let inline is11<'T> = Width (Mobile, Is11)
            let inline isNarrow<'T> = Width (Mobile, IsNarrow)
            let inline isFull<'T> = Width (Mobile, IsFull)

        module Tablet =
            let inline isOneQuarter<'T> = Width (Tablet, IsOneQuarter)
            let inline isOneThird<'T> = Width (Tablet, IsOneThird)
            let inline isHalf<'T> = Width (Tablet, IsHalf)
            let inline isTwoThirds<'T> = Width (Tablet, IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (Tablet, IsThreeQuarters)
            let inline is1<'T> = Width (Tablet, Is1)
            let inline is2<'T> = Width (Tablet, Is2)
            let inline is3<'T> = Width (Tablet, Is3)
            let inline is4<'T> = Width (Tablet, Is4)
            let inline is5<'T> = Width (Tablet, Is5)
            let inline is6<'T> = Width (Tablet, Is6)
            let inline is7<'T> = Width (Tablet, Is7)
            let inline is8<'T> = Width (Tablet, Is8)
            let inline is9<'T> = Width (Tablet, Is9)
            let inline is10<'T> = Width (Tablet, Is10)
            let inline is11<'T> = Width (Tablet, Is11)
            let inline isNarrow<'T> = Width (Tablet, IsNarrow)
            let inline isFull<'T> = Width (Tablet, IsFull)

        let inline isOneQuarter<'T> = Width (All, IsOneQuarter)
        let inline isOneThird<'T> = Width (All, IsOneThird)
        let inline isHalf<'T> = Width (All, IsHalf)
        let inline isTwoThirds<'T> = Width (All, IsTwoThirds)
        let inline isThreeQuarters<'T> = Width (All, IsThreeQuarters)
        let inline is1<'T> = Width (All, Is1)
        let inline is2<'T> = Width (All, Is2)
        let inline is3<'T> = Width (All, Is3)
        let inline is4<'T> = Width (All, Is4)
        let inline is5<'T> = Width (All, Is5)
        let inline is6<'T> = Width (All, Is6)
        let inline is7<'T> = Width (All, Is7)
        let inline is8<'T> = Width (All, Is8)
        let inline is9<'T> = Width (All, Is9)
        let inline is10<'T> = Width (All, Is10)
        let inline is11<'T> = Width (All, Is11)
        let inline isNarrow<'T> = Width (All, IsNarrow)
        let inline isFull<'T> = Width (All, IsFull)

    module Offset =

        module Dekstop =
            let inline isOneQuarter<'T> = Offset (Desktop, IsOneQuarter)
            let inline isOneThird<'T> = Offset (Desktop, IsOneThird)
            let inline isHalf<'T> = Offset (Desktop, IsHalf)
            let inline isTwoThirds<'T> = Offset (Desktop, IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (Desktop, IsThreeQuarters)
            let inline is1<'T> = Offset (Desktop, Is1)
            let inline is2<'T> = Offset (Desktop, Is2)
            let inline is3<'T> = Offset (Desktop, Is3)
            let inline is4<'T> = Offset (Desktop, Is4)
            let inline is5<'T> = Offset (Desktop, Is5)
            let inline is6<'T> = Offset (Desktop, Is6)
            let inline is7<'T> = Offset (Desktop, Is7)
            let inline is8<'T> = Offset (Desktop, Is8)
            let inline is9<'T> = Offset (Desktop, Is9)
            let inline is10<'T> = Offset (Desktop, Is10)
            let inline is11<'T> = Offset (Desktop, Is11)
            let inline isNarrow<'T> = Offset (Desktop, IsNarrow)
            let inline isFull<'T> = Offset (Desktop, IsFull)

        module WideScreen =
            let inline isOneQuarter<'T> = Offset (WideScreen, IsOneQuarter)
            let inline isOneThird<'T> = Offset (WideScreen, IsOneThird)
            let inline isHalf<'T> = Offset (WideScreen, IsHalf)
            let inline isTwoThirds<'T> = Offset (WideScreen, IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (WideScreen, IsThreeQuarters)
            let inline is1<'T> = Offset (WideScreen, Is1)
            let inline is2<'T> = Offset (WideScreen, Is2)
            let inline is3<'T> = Offset (WideScreen, Is3)
            let inline is4<'T> = Offset (WideScreen, Is4)
            let inline is5<'T> = Offset (WideScreen, Is5)
            let inline is6<'T> = Offset (WideScreen, Is6)
            let inline is7<'T> = Offset (WideScreen, Is7)
            let inline is8<'T> = Offset (WideScreen, Is8)
            let inline is9<'T> = Offset (WideScreen, Is9)
            let inline is10<'T> = Offset (WideScreen, Is10)
            let inline is11<'T> = Offset (WideScreen, Is11)
            let inline isNarrow<'T> = Offset (WideScreen, IsNarrow)
            let inline isFull<'T> = Offset (WideScreen, IsFull)

        module Mobile =
            let inline isOneQuarter<'T> = Offset (Mobile, IsOneQuarter)
            let inline isOneThird<'T> = Offset (Mobile, IsOneThird)
            let inline isHalf<'T> = Offset (Mobile, IsHalf)
            let inline isTwoThirds<'T> = Offset (Mobile, IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (Mobile, IsThreeQuarters)
            let inline is1<'T> = Offset (Mobile, Is1)
            let inline is2<'T> = Offset (Mobile, Is2)
            let inline is3<'T> = Offset (Mobile, Is3)
            let inline is4<'T> = Offset (Mobile, Is4)
            let inline is5<'T> = Offset (Mobile, Is5)
            let inline is6<'T> = Offset (Mobile, Is6)
            let inline is7<'T> = Offset (Mobile, Is7)
            let inline is8<'T> = Offset (Mobile, Is8)
            let inline is9<'T> = Offset (Mobile, Is9)
            let inline is10<'T> = Offset (Mobile, Is10)
            let inline is11<'T> = Offset (Mobile, Is11)
            let inline isNarrow<'T> = Offset (Mobile, IsNarrow)
            let inline isFull<'T> = Offset (Mobile, IsFull)

        module Tablet =
            let inline isOneQuarter<'T> = Offset (Tablet, IsOneQuarter)
            let inline isOneThird<'T> = Offset (Tablet, IsOneThird)
            let inline isHalf<'T> = Offset (Tablet, IsHalf)
            let inline isTwoThirds<'T> = Offset (Tablet, IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (Tablet, IsThreeQuarters)
            let inline is1<'T> = Offset (Tablet, Is1)
            let inline is2<'T> = Offset (Tablet, Is2)
            let inline is3<'T> = Offset (Tablet, Is3)
            let inline is4<'T> = Offset (Tablet, Is4)
            let inline is5<'T> = Offset (Tablet, Is5)
            let inline is6<'T> = Offset (Tablet, Is6)
            let inline is7<'T> = Offset (Tablet, Is7)
            let inline is8<'T> = Offset (Tablet, Is8)
            let inline is9<'T> = Offset (Tablet, Is9)
            let inline is10<'T> = Offset (Tablet, Is10)
            let inline is11<'T> = Offset (Tablet, Is11)
            let inline isNarrow<'T> = Offset (Tablet, IsNarrow)
            let inline isFull<'T> = Offset (Tablet, IsFull)

        let inline isOneQuarter<'T> = Offset (All, IsOneQuarter)
        let inline isOneThird<'T> = Offset (All, IsOneThird)
        let inline isHalf<'T> = Offset (All, IsHalf)
        let inline isTwoThirds<'T> = Offset (All, IsTwoThirds)
        let inline isThreeQuarters<'T> = Offset (All, IsThreeQuarters)
        let inline is1<'T> = Offset (All, Is1)
        let inline is2<'T> = Offset (All, Is2)
        let inline is3<'T> = Offset (All, Is3)
        let inline is4<'T> = Offset (All, Is4)
        let inline is5<'T> = Offset (All, Is5)
        let inline is6<'T> = Offset (All, Is6)
        let inline is7<'T> = Offset (All, Is7)
        let inline is8<'T> = Offset (All, Is8)
        let inline is9<'T> = Offset (All, Is9)
        let inline is10<'T> = Offset (All, Is10)
        let inline is11<'T> = Offset (All, Is11)
        let inline isNarrow<'T> = Offset (All, IsNarrow)
        let inline isFull<'T> = Offset (All, IsFull)

    // Extra
    let inline customClass x = CustomClass x
    let inline props x = Props x

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
            | x ->
                Fable.Import.JS.console.warn("Error when parsing column option " + string x)
                result

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
