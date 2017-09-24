namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Column =

    module Types =

        type ISize =
            | IsOneQuarter = 1
            | IsOneThird = 2
            | IsHalf = 3
            | IsTwoThirds = 4
            | IsThreeQuarters = 5
            | Is1 = 6
            | Is2 = 7
            | Is3 = 8
            | Is4 = 9
            | Is5 = 10
            | Is6 = 11
            | Is7 = 12
            | Is8 = 13
            | Is9 = 14
            | Is10 = 15
            | Is11 = 16
            | IsNarrow = 17
            | IsFull = 18

        type IScreen =
            | All = 1
            | Desktop = 2
            | Tablet = 3
            | Mobile = 4
            | WideScreen = 5

        type Option =
            | Width of IScreen * ISize
            | Offset of IScreen * ISize
            | CustomClass of string
            | Props of IHTMLProp list

        let ofWidth =
            function
            | IScreen.All, size ->
                match size with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Width.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Width.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Width.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Width.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Width.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Width.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Width.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Width.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Width.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Width.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Width.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Width.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Width.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Width.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Width.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Width.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Width.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Width.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.Desktop, size ->
                match size with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Desktop.Width.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Desktop.Width.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Desktop.Width.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Desktop.Width.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Desktop.Width.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Desktop.Width.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Desktop.Width.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Desktop.Width.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Desktop.Width.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Desktop.Width.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Desktop.Width.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Desktop.Width.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Desktop.Width.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Desktop.Width.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Desktop.Width.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Desktop.Width.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Desktop.Width.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Desktop.Width.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.Tablet, size ->
                match size with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Tablet.Width.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Tablet.Width.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Tablet.Width.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Tablet.Width.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Tablet.Width.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Tablet.Width.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Tablet.Width.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Tablet.Width.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Tablet.Width.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Tablet.Width.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Tablet.Width.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Tablet.Width.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Tablet.Width.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Tablet.Width.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Tablet.Width.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Tablet.Width.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Tablet.Width.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Tablet.Width.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.Mobile, size ->
                match size with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Mobile.Width.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Mobile.Width.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Mobile.Width.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Mobile.Width.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Mobile.Width.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Mobile.Width.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Mobile.Width.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Mobile.Width.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Mobile.Width.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Mobile.Width.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Mobile.Width.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Mobile.Width.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Mobile.Width.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Mobile.Width.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Mobile.Width.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Mobile.Width.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Mobile.Width.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Mobile.Width.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.WideScreen, size ->
                match size with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.WideScreen.Width.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.WideScreen.Width.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.WideScreen.Width.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.WideScreen.Width.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.WideScreen.Width.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.WideScreen.Width.Is1
                | ISize.Is2 -> Bulma.Grid.Column.WideScreen.Width.Is2
                | ISize.Is3 -> Bulma.Grid.Column.WideScreen.Width.Is3
                | ISize.Is4 -> Bulma.Grid.Column.WideScreen.Width.Is4
                | ISize.Is5 -> Bulma.Grid.Column.WideScreen.Width.Is5
                | ISize.Is6 -> Bulma.Grid.Column.WideScreen.Width.Is6
                | ISize.Is7 -> Bulma.Grid.Column.WideScreen.Width.Is7
                | ISize.Is8 -> Bulma.Grid.Column.WideScreen.Width.Is8
                | ISize.Is9 -> Bulma.Grid.Column.WideScreen.Width.Is9
                | ISize.Is10 -> Bulma.Grid.Column.WideScreen.Width.Is10
                | ISize.Is11 -> Bulma.Grid.Column.WideScreen.Width.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.WideScreen.Width.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.WideScreen.Width.IsFull
                | _ -> failwith "Unknow ISize case"
            | _ -> failwith "Unknow IScreen case"

        let ofOffset =
            function
            | IScreen.All, offset ->
                match offset with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Offset.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Offset.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Offset.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Offset.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Offset.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Offset.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Offset.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Offset.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Offset.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Offset.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Offset.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Offset.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Offset.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Offset.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Offset.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Offset.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Offset.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Offset.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.Desktop, offset ->
                match offset with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Desktop.Offset.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Desktop.Offset.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Desktop.Offset.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Desktop.Offset.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Desktop.Offset.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Desktop.Offset.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Desktop.Offset.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Desktop.Offset.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Desktop.Offset.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Desktop.Offset.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Desktop.Offset.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Desktop.Offset.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Desktop.Offset.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Desktop.Offset.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Desktop.Offset.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Desktop.Offset.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Desktop.Offset.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Desktop.Offset.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.Tablet, offset ->
                match offset with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Tablet.Offset.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Tablet.Offset.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Tablet.Offset.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Tablet.Offset.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Tablet.Offset.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Tablet.Offset.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Tablet.Offset.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Tablet.Offset.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Tablet.Offset.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Tablet.Offset.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Tablet.Offset.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Tablet.Offset.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Tablet.Offset.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Tablet.Offset.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Tablet.Offset.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Tablet.Offset.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Tablet.Offset.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Tablet.Offset.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.Mobile, offset ->
                match offset with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.Mobile.Offset.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.Mobile.Offset.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.Mobile.Offset.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.Mobile.Offset.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.Mobile.Offset.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.Mobile.Offset.Is1
                | ISize.Is2 -> Bulma.Grid.Column.Mobile.Offset.Is2
                | ISize.Is3 -> Bulma.Grid.Column.Mobile.Offset.Is3
                | ISize.Is4 -> Bulma.Grid.Column.Mobile.Offset.Is4
                | ISize.Is5 -> Bulma.Grid.Column.Mobile.Offset.Is5
                | ISize.Is6 -> Bulma.Grid.Column.Mobile.Offset.Is6
                | ISize.Is7 -> Bulma.Grid.Column.Mobile.Offset.Is7
                | ISize.Is8 -> Bulma.Grid.Column.Mobile.Offset.Is8
                | ISize.Is9 -> Bulma.Grid.Column.Mobile.Offset.Is9
                | ISize.Is10 -> Bulma.Grid.Column.Mobile.Offset.Is10
                | ISize.Is11 -> Bulma.Grid.Column.Mobile.Offset.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.Mobile.Offset.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.Mobile.Offset.IsFull
                | _ -> failwith "Unknow ISize case"
            | IScreen.WideScreen, offset ->
                match offset with
                | ISize.IsOneQuarter -> Bulma.Grid.Column.WideScreen.Offset.IsOneQuarter
                | ISize.IsOneThird -> Bulma.Grid.Column.WideScreen.Offset.IsOneThird
                | ISize.IsHalf -> Bulma.Grid.Column.WideScreen.Offset.IsHalf
                | ISize.IsTwoThirds -> Bulma.Grid.Column.WideScreen.Offset.IsTwoThirds
                | ISize.IsThreeQuarters -> Bulma.Grid.Column.WideScreen.Offset.IsThreeQuarters
                | ISize.Is1 -> Bulma.Grid.Column.WideScreen.Offset.Is1
                | ISize.Is2 -> Bulma.Grid.Column.WideScreen.Offset.Is2
                | ISize.Is3 -> Bulma.Grid.Column.WideScreen.Offset.Is3
                | ISize.Is4 -> Bulma.Grid.Column.WideScreen.Offset.Is4
                | ISize.Is5 -> Bulma.Grid.Column.WideScreen.Offset.Is5
                | ISize.Is6 -> Bulma.Grid.Column.WideScreen.Offset.Is6
                | ISize.Is7 -> Bulma.Grid.Column.WideScreen.Offset.Is7
                | ISize.Is8 -> Bulma.Grid.Column.WideScreen.Offset.Is8
                | ISize.Is9 -> Bulma.Grid.Column.WideScreen.Offset.Is9
                | ISize.Is10 -> Bulma.Grid.Column.WideScreen.Offset.Is10
                | ISize.Is11 -> Bulma.Grid.Column.WideScreen.Offset.Is11
                | ISize.IsNarrow -> Bulma.Grid.Column.WideScreen.Offset.IsNarrow
                | ISize.IsFull -> Bulma.Grid.Column.WideScreen.Offset.IsFull
                | _ -> failwith "Unknow ISize case"
            | _ -> failwith "Unknow IScreen case"

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

        module Desktop =
            let inline isOneQuarter<'T> = Width (IScreen.Desktop, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Width (IScreen.Desktop, ISize.IsOneThird)
            let inline isHalf<'T> = Width (IScreen.Desktop, ISize.IsHalf)
            let inline isTwoThirds<'T> = Width (IScreen.Desktop, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (IScreen.Desktop, ISize.IsThreeQuarters)
            let inline is1<'T> = Width (IScreen.Desktop, ISize.Is1)
            let inline is2<'T> = Width (IScreen.Desktop, ISize.Is2)
            let inline is3<'T> = Width (IScreen.Desktop, ISize.Is3)
            let inline is4<'T> = Width (IScreen.Desktop, ISize.Is4)
            let inline is5<'T> = Width (IScreen.Desktop, ISize.Is5)
            let inline is6<'T> = Width (IScreen.Desktop, ISize.Is6)
            let inline is7<'T> = Width (IScreen.Desktop, ISize.Is7)
            let inline is8<'T> = Width (IScreen.Desktop, ISize.Is8)
            let inline is9<'T> = Width (IScreen.Desktop, ISize.Is9)
            let inline is10<'T> = Width (IScreen.Desktop, ISize.Is10)
            let inline is11<'T> = Width (IScreen.Desktop, ISize.Is11)
            let inline isNarrow<'T> = Width (IScreen.Desktop, ISize.IsNarrow)
            let inline isFull<'T> = Width (IScreen.Desktop, ISize.IsFull)

        module WideScreen =
            let inline isOneQuarter<'T> = Width (IScreen.WideScreen, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Width (IScreen.WideScreen, ISize.IsOneThird)
            let inline isHalf<'T> = Width (IScreen.WideScreen, ISize.IsHalf)
            let inline isTwoThirds<'T> = Width (IScreen.WideScreen, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (IScreen.WideScreen, ISize.IsThreeQuarters)
            let inline is1<'T> = Width (IScreen.WideScreen, ISize.Is1)
            let inline is2<'T> = Width (IScreen.WideScreen, ISize.Is2)
            let inline is3<'T> = Width (IScreen.WideScreen, ISize.Is3)
            let inline is4<'T> = Width (IScreen.WideScreen, ISize.Is4)
            let inline is5<'T> = Width (IScreen.WideScreen, ISize.Is5)
            let inline is6<'T> = Width (IScreen.WideScreen, ISize.Is6)
            let inline is7<'T> = Width (IScreen.WideScreen, ISize.Is7)
            let inline is8<'T> = Width (IScreen.WideScreen, ISize.Is8)
            let inline is9<'T> = Width (IScreen.WideScreen, ISize.Is9)
            let inline is10<'T> = Width (IScreen.WideScreen, ISize.Is10)
            let inline is11<'T> = Width (IScreen.WideScreen, ISize.Is11)
            let inline isNarrow<'T> = Width (IScreen.WideScreen, ISize.IsNarrow)
            let inline isFull<'T> = Width (IScreen.WideScreen, ISize.IsFull)

        module Mobile =
            let inline isOneQuarter<'T> = Width (IScreen.Mobile, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Width (IScreen.Mobile, ISize.IsOneThird)
            let inline isHalf<'T> = Width (IScreen.Mobile, ISize.IsHalf)
            let inline isTwoThirds<'T> = Width (IScreen.Mobile, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (IScreen.Mobile, ISize.IsThreeQuarters)
            let inline is1<'T> = Width (IScreen.Mobile, ISize.Is1)
            let inline is2<'T> = Width (IScreen.Mobile, ISize.Is2)
            let inline is3<'T> = Width (IScreen.Mobile, ISize.Is3)
            let inline is4<'T> = Width (IScreen.Mobile, ISize.Is4)
            let inline is5<'T> = Width (IScreen.Mobile, ISize.Is5)
            let inline is6<'T> = Width (IScreen.Mobile, ISize.Is6)
            let inline is7<'T> = Width (IScreen.Mobile, ISize.Is7)
            let inline is8<'T> = Width (IScreen.Mobile, ISize.Is8)
            let inline is9<'T> = Width (IScreen.Mobile, ISize.Is9)
            let inline is10<'T> = Width (IScreen.Mobile, ISize.Is10)
            let inline is11<'T> = Width (IScreen.Mobile, ISize.Is11)
            let inline isNarrow<'T> = Width (IScreen.Mobile, ISize.IsNarrow)
            let inline isFull<'T> = Width (IScreen.Mobile, ISize.IsFull)

        module Tablet =
            let inline isOneQuarter<'T> = Width (IScreen.Tablet, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Width (IScreen.Tablet, ISize.IsOneThird)
            let inline isHalf<'T> = Width (IScreen.Tablet, ISize.IsHalf)
            let inline isTwoThirds<'T> = Width (IScreen.Tablet, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Width (IScreen.Tablet, ISize.IsThreeQuarters)
            let inline is1<'T> = Width (IScreen.Tablet, ISize.Is1)
            let inline is2<'T> = Width (IScreen.Tablet, ISize.Is2)
            let inline is3<'T> = Width (IScreen.Tablet, ISize.Is3)
            let inline is4<'T> = Width (IScreen.Tablet, ISize.Is4)
            let inline is5<'T> = Width (IScreen.Tablet, ISize.Is5)
            let inline is6<'T> = Width (IScreen.Tablet, ISize.Is6)
            let inline is7<'T> = Width (IScreen.Tablet, ISize.Is7)
            let inline is8<'T> = Width (IScreen.Tablet, ISize.Is8)
            let inline is9<'T> = Width (IScreen.Tablet, ISize.Is9)
            let inline is10<'T> = Width (IScreen.Tablet, ISize.Is10)
            let inline is11<'T> = Width (IScreen.Tablet, ISize.Is11)
            let inline isNarrow<'T> = Width (IScreen.Tablet, ISize.IsNarrow)
            let inline isFull<'T> = Width (IScreen.Tablet, ISize.IsFull)

        let inline isOneQuarter<'T> = Width (IScreen.All, ISize.IsOneQuarter)
        let inline isOneThird<'T> = Width (IScreen.All, ISize.IsOneThird)
        let inline isHalf<'T> = Width (IScreen.All, ISize.IsHalf)
        let inline isTwoThirds<'T> = Width (IScreen.All, ISize.IsTwoThirds)
        let inline isThreeQuarters<'T> = Width (IScreen.All, ISize.IsThreeQuarters)
        let inline is1<'T> = Width (IScreen.All, ISize.Is1)
        let inline is2<'T> = Width (IScreen.All, ISize.Is2)
        let inline is3<'T> = Width (IScreen.All, ISize.Is3)
        let inline is4<'T> = Width (IScreen.All, ISize.Is4)
        let inline is5<'T> = Width (IScreen.All, ISize.Is5)
        let inline is6<'T> = Width (IScreen.All, ISize.Is6)
        let inline is7<'T> = Width (IScreen.All, ISize.Is7)
        let inline is8<'T> = Width (IScreen.All, ISize.Is8)
        let inline is9<'T> = Width (IScreen.All, ISize.Is9)
        let inline is10<'T> = Width (IScreen.All, ISize.Is10)
        let inline is11<'T> = Width (IScreen.All, ISize.Is11)
        let inline isNarrow<'T> = Width (IScreen.All, ISize.IsNarrow)
        let inline isFull<'T> = Width (IScreen.All, ISize.IsFull)

    module Offset =

        module Desktop =
            let inline isOneQuarter<'T> = Offset (IScreen.Desktop, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Offset (IScreen.Desktop, ISize.IsOneThird)
            let inline isHalf<'T> = Offset (IScreen.Desktop, ISize.IsHalf)
            let inline isTwoThirds<'T> = Offset (IScreen.Desktop, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (IScreen.Desktop, ISize.IsThreeQuarters)
            let inline is1<'T> = Offset (IScreen.Desktop, ISize.Is1)
            let inline is2<'T> = Offset (IScreen.Desktop, ISize.Is2)
            let inline is3<'T> = Offset (IScreen.Desktop, ISize.Is3)
            let inline is4<'T> = Offset (IScreen.Desktop, ISize.Is4)
            let inline is5<'T> = Offset (IScreen.Desktop, ISize.Is5)
            let inline is6<'T> = Offset (IScreen.Desktop, ISize.Is6)
            let inline is7<'T> = Offset (IScreen.Desktop, ISize.Is7)
            let inline is8<'T> = Offset (IScreen.Desktop, ISize.Is8)
            let inline is9<'T> = Offset (IScreen.Desktop, ISize.Is9)
            let inline is10<'T> = Offset (IScreen.Desktop, ISize.Is10)
            let inline is11<'T> = Offset (IScreen.Desktop, ISize.Is11)
            let inline isNarrow<'T> = Offset (IScreen.Desktop, ISize.IsNarrow)
            let inline isFull<'T> = Offset (IScreen.Desktop, ISize.IsFull)

        module WideScreen =
            let inline isOneQuarter<'T> = Offset (IScreen.WideScreen, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Offset (IScreen.WideScreen, ISize.IsOneThird)
            let inline isHalf<'T> = Offset (IScreen.WideScreen, ISize.IsHalf)
            let inline isTwoThirds<'T> = Offset (IScreen.WideScreen, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (IScreen.WideScreen, ISize.IsThreeQuarters)
            let inline is1<'T> = Offset (IScreen.WideScreen, ISize.Is1)
            let inline is2<'T> = Offset (IScreen.WideScreen, ISize.Is2)
            let inline is3<'T> = Offset (IScreen.WideScreen, ISize.Is3)
            let inline is4<'T> = Offset (IScreen.WideScreen, ISize.Is4)
            let inline is5<'T> = Offset (IScreen.WideScreen, ISize.Is5)
            let inline is6<'T> = Offset (IScreen.WideScreen, ISize.Is6)
            let inline is7<'T> = Offset (IScreen.WideScreen, ISize.Is7)
            let inline is8<'T> = Offset (IScreen.WideScreen, ISize.Is8)
            let inline is9<'T> = Offset (IScreen.WideScreen, ISize.Is9)
            let inline is10<'T> = Offset (IScreen.WideScreen, ISize.Is10)
            let inline is11<'T> = Offset (IScreen.WideScreen, ISize.Is11)
            let inline isNarrow<'T> = Offset (IScreen.WideScreen, ISize.IsNarrow)
            let inline isFull<'T> = Offset (IScreen.WideScreen, ISize.IsFull)

        module Mobile =
            let inline isOneQuarter<'T> = Offset (IScreen.Mobile, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Offset (IScreen.Mobile, ISize.IsOneThird)
            let inline isHalf<'T> = Offset (IScreen.Mobile, ISize.IsHalf)
            let inline isTwoThirds<'T> = Offset (IScreen.Mobile, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (IScreen.Mobile, ISize.IsThreeQuarters)
            let inline is1<'T> = Offset (IScreen.Mobile, ISize.Is1)
            let inline is2<'T> = Offset (IScreen.Mobile, ISize.Is2)
            let inline is3<'T> = Offset (IScreen.Mobile, ISize.Is3)
            let inline is4<'T> = Offset (IScreen.Mobile, ISize.Is4)
            let inline is5<'T> = Offset (IScreen.Mobile, ISize.Is5)
            let inline is6<'T> = Offset (IScreen.Mobile, ISize.Is6)
            let inline is7<'T> = Offset (IScreen.Mobile, ISize.Is7)
            let inline is8<'T> = Offset (IScreen.Mobile, ISize.Is8)
            let inline is9<'T> = Offset (IScreen.Mobile, ISize.Is9)
            let inline is10<'T> = Offset (IScreen.Mobile, ISize.Is10)
            let inline is11<'T> = Offset (IScreen.Mobile, ISize.Is11)
            let inline isNarrow<'T> = Offset (IScreen.Mobile, ISize.IsNarrow)
            let inline isFull<'T> = Offset (IScreen.Mobile, ISize.IsFull)

        module Tablet =
            let inline isOneQuarter<'T> = Offset (IScreen.Tablet, ISize.IsOneQuarter)
            let inline isOneThird<'T> = Offset (IScreen.Tablet, ISize.IsOneThird)
            let inline isHalf<'T> = Offset (IScreen.Tablet, ISize.IsHalf)
            let inline isTwoThirds<'T> = Offset (IScreen.Tablet, ISize.IsTwoThirds)
            let inline isThreeQuarters<'T> = Offset (IScreen.Tablet, ISize.IsThreeQuarters)
            let inline is1<'T> = Offset (IScreen.Tablet, ISize.Is1)
            let inline is2<'T> = Offset (IScreen.Tablet, ISize.Is2)
            let inline is3<'T> = Offset (IScreen.Tablet, ISize.Is3)
            let inline is4<'T> = Offset (IScreen.Tablet, ISize.Is4)
            let inline is5<'T> = Offset (IScreen.Tablet, ISize.Is5)
            let inline is6<'T> = Offset (IScreen.Tablet, ISize.Is6)
            let inline is7<'T> = Offset (IScreen.Tablet, ISize.Is7)
            let inline is8<'T> = Offset (IScreen.Tablet, ISize.Is8)
            let inline is9<'T> = Offset (IScreen.Tablet, ISize.Is9)
            let inline is10<'T> = Offset (IScreen.Tablet, ISize.Is10)
            let inline is11<'T> = Offset (IScreen.Tablet, ISize.Is11)
            let inline isNarrow<'T> = Offset (IScreen.Tablet, ISize.IsNarrow)
            let inline isFull<'T> = Offset (IScreen.Tablet, ISize.IsFull)

        let inline isOneQuarter<'T> = Offset (IScreen.All, ISize.IsOneQuarter)
        let inline isOneThird<'T> = Offset (IScreen.All, ISize.IsOneThird)
        let inline isHalf<'T> = Offset (IScreen.All, ISize.IsHalf)
        let inline isTwoThirds<'T> = Offset (IScreen.All, ISize.IsTwoThirds)
        let inline isThreeQuarters<'T> = Offset (IScreen.All, ISize.IsThreeQuarters)
        let inline is1<'T> = Offset (IScreen.All, ISize.Is1)
        let inline is2<'T> = Offset (IScreen.All, ISize.Is2)
        let inline is3<'T> = Offset (IScreen.All, ISize.Is3)
        let inline is4<'T> = Offset (IScreen.All, ISize.Is4)
        let inline is5<'T> = Offset (IScreen.All, ISize.Is5)
        let inline is6<'T> = Offset (IScreen.All, ISize.Is6)
        let inline is7<'T> = Offset (IScreen.All, ISize.Is7)
        let inline is8<'T> = Offset (IScreen.All, ISize.Is8)
        let inline is9<'T> = Offset (IScreen.All, ISize.Is9)
        let inline is10<'T> = Offset (IScreen.All, ISize.Is10)
        let inline is11<'T> = Offset (IScreen.All, ISize.Is11)
        let inline isNarrow<'T> = Offset (IScreen.All, ISize.IsNarrow)
        let inline isFull<'T> = Offset (IScreen.All, ISize.IsFull)

    // Extra
    let inline customClass<'T> = CustomClass
    let inline props<'T> = Props

    let column (options : Option list) children =
        let parseOptions (result: Options) =
            function
            | Width (screen, width) when screen = IScreen.All ->
                { result with Width = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = IScreen.All ->
                { result with Offset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = IScreen.Desktop ->
                { result with DesktopWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = IScreen.Desktop ->
                { result with DesktopOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = IScreen.Tablet ->
                { result with TabletpWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = IScreen.Tablet ->
                { result with TabletpOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = IScreen.Mobile ->
                { result with MobileWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = IScreen.Mobile ->
                { result with MobileOffset = ofOffset (screen, offset) |> Some }
            | Width (screen, width) when screen = IScreen.WideScreen ->
                { result with WideScreenpWidth = ofWidth (screen, width) |> Some }
            | Offset (screen, offset) when screen = IScreen.WideScreen ->
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
