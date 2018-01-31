namespace Fulma.Layouts

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Column =

    module Classes =
        let [<Literal>] Container = "column"

        module All =
            module Width =
                let [<Literal>] IsOneQuarter = "is-one-quarter"
                let [<Literal>] IsOneThird = "is-one-third"
                let [<Literal>] IsHalf = "is-half"
                let [<Literal>] IsTwoThirds = "is-two-third"
                let [<Literal>] IsThreeQuarters = "is-three-quarters"
                let [<Literal>] Is1 = "is-1"
                let [<Literal>] Is2 = "is-2"
                let [<Literal>] Is3 = "is-3"
                let [<Literal>] Is4 = "is-4"
                let [<Literal>] Is5 = "is-5"
                let [<Literal>] Is6 = "is-6"
                let [<Literal>] Is7 = "is-7"
                let [<Literal>] Is8 = "is-8"
                let [<Literal>] Is9 = "is-9"
                let [<Literal>] Is10 = "is-10"
                let [<Literal>] Is11 = "is-11"
                let [<Literal>] IsNarrow = "is-narrow"
                let [<Literal>] IsFull = "is-full"
                let [<Literal>] IsOneFifth = "is-one-fifth"
                let [<Literal>] IsTwoFifths = "is-two-fifths"
                let [<Literal>] IsThreeFifths = "is-three-fifths"
                let [<Literal>] IsFourFifths = "is-four-fifths"

            module Offset =
                let [<Literal>] IsOneQuarter = "is-offset-one-quarter"
                let [<Literal>] IsOneThird = "is-offset-one-third"
                let [<Literal>] IsHalf = "is-offset-half"
                let [<Literal>] IsTwoThirds = "is-offset-two-third"
                let [<Literal>] IsThreeQuarters = "is-offset-three-quarters"
                let [<Literal>] Is1 = "is-offset-1"
                let [<Literal>] Is2 = "is-offset-2"
                let [<Literal>] Is3 = "is-offset-3"
                let [<Literal>] Is4 = "is-offset-4"
                let [<Literal>] Is5 = "is-offset-5"
                let [<Literal>] Is6 = "is-offset-6"
                let [<Literal>] Is7 = "is-offset-7"
                let [<Literal>] Is8 = "is-offset-8"
                let [<Literal>] Is9 = "is-offset-9"
                let [<Literal>] Is10 = "is-offset-10"
                let [<Literal>] Is11 = "is-offset-11"
                let [<Literal>] IsNarrow = "is-offset-narrow"
                let [<Literal>] IsFull = "is-offset-full"
                let [<Literal>] IsOneFifth = "is-offset-one-fifth"
                let [<Literal>] IsTwoFifths = "is-offset-two-fifths"
                let [<Literal>] IsThreeFifths = "is-offset-three-fifths"
                let [<Literal>] IsFourFifths = "is-offset-four-fifths"

        module Desktop =
            module Width =
                let [<Literal>] IsOneQuarter = "is-one-quarter-desktop"
                let [<Literal>] IsOneThird = "is-one-third-desktop"
                let [<Literal>] IsHalf = "is-half-desktop"
                let [<Literal>] IsTwoThirds = "is-two-third-desktop"
                let [<Literal>] IsThreeQuarters = "is-three-quarters-desktop"
                let [<Literal>] Is1 = "is-1-desktop"
                let [<Literal>] Is2 = "is-2-desktop"
                let [<Literal>] Is3 = "is-3-desktop"
                let [<Literal>] Is4 = "is-4-desktop"
                let [<Literal>] Is5 = "is-5-desktop"
                let [<Literal>] Is6 = "is-6-desktop"
                let [<Literal>] Is7 = "is-7-desktop"
                let [<Literal>] Is8 = "is-8-desktop"
                let [<Literal>] Is9 = "is-9-desktop"
                let [<Literal>] Is10 = "is-10-desktop"
                let [<Literal>] Is11 = "is-11-desktop"
                let [<Literal>] IsNarrow = "is-narrow-desktop"
                let [<Literal>] IsFull = "is-full-desktop"
                let [<Literal>] IsOneFifth = "is-one-fifth-desktop"
                let [<Literal>] IsTwoFifths = "is-two-fifths-desktop"
                let [<Literal>] IsThreeFifths = "is-three-fifths-desktop"
                let [<Literal>] IsFourFifths = "is-four-fifths-desktop"

            module Offset =
                let [<Literal>] IsOneQuarter = "is-offset-one-quarter-desktop"
                let [<Literal>] IsOneThird = "is-offset-one-third-desktop"
                let [<Literal>] IsHalf = "is-offset-half-desktop"
                let [<Literal>] IsTwoThirds = "is-offset-two-third-desktop"
                let [<Literal>] IsThreeQuarters = "is-offset-three-quarters-desktop"
                let [<Literal>] Is1 = "is-offset-1-desktop"
                let [<Literal>] Is2 = "is-offset-2-desktop"
                let [<Literal>] Is3 = "is-offset-3-desktop"
                let [<Literal>] Is4 = "is-offset-4-desktop"
                let [<Literal>] Is5 = "is-offset-5-desktop"
                let [<Literal>] Is6 = "is-offset-6-desktop"
                let [<Literal>] Is7 = "is-offset-7-desktop"
                let [<Literal>] Is8 = "is-offset-8-desktop"
                let [<Literal>] Is9 = "is-offset-9-desktop"
                let [<Literal>] Is10 = "is-offset-10-desktop"
                let [<Literal>] Is11 = "is-offset-11-desktop"
                let [<Literal>] IsNarrow = "is-offset-narrow-desktop"
                let [<Literal>] IsFull = "is-offset-full-desktop"
                let [<Literal>] IsOneFifth = "is-offset-one-fifth-desktop"
                let [<Literal>] IsTwoFifths = "is-offset-two-fifths-desktop"
                let [<Literal>] IsThreeFifths = "is-offset-three-fifths-desktop"
                let [<Literal>] IsFourFifths = "is-offset-four-fifths-desktop"

        module Mobile =
            module Width =
                let [<Literal>] IsOneQuarter = "is-one-quarter-mobile"
                let [<Literal>] IsOneThird = "is-one-third-mobile"
                let [<Literal>] IsHalf = "is-half-mobile"
                let [<Literal>] IsTwoThirds = "is-two-third-mobile"
                let [<Literal>] IsThreeQuarters = "is-three-quarters-mobile"
                let [<Literal>] Is1 = "is-1-mobile"
                let [<Literal>] Is2 = "is-2-mobile"
                let [<Literal>] Is3 = "is-3-mobile"
                let [<Literal>] Is4 = "is-4-mobile"
                let [<Literal>] Is5 = "is-5-mobile"
                let [<Literal>] Is6 = "is-6-mobile"
                let [<Literal>] Is7 = "is-7-mobile"
                let [<Literal>] Is8 = "is-8-mobile"
                let [<Literal>] Is9 = "is-9-mobile"
                let [<Literal>] Is10 = "is-10-mobile"
                let [<Literal>] Is11 = "is-11-mobile"
                let [<Literal>] IsNarrow = "is-narrow-mobile"
                let [<Literal>] IsFull = "is-full-mobile"
                let [<Literal>] IsOneFifth = "is-one-fifth-mobile"
                let [<Literal>] IsTwoFifths = "is-two-fifths-mobile"
                let [<Literal>] IsThreeFifths = "is-three-fifths-mobile"
                let [<Literal>] IsFourFifths = "is-four-fifths-mobile"

            module Offset =
                let [<Literal>] IsOneQuarter = "is-offset-one-quarter-mobile"
                let [<Literal>] IsOneThird = "is-offset-one-third-mobile"
                let [<Literal>] IsHalf = "is-offset-half-mobile"
                let [<Literal>] IsTwoThirds = "is-offset-two-third-mobile"
                let [<Literal>] IsThreeQuarters = "is-offset-three-quarters-mobile"
                let [<Literal>] Is1 = "is-offset-1-mobile"
                let [<Literal>] Is2 = "is-offset-2-mobile"
                let [<Literal>] Is3 = "is-offset-3-mobile"
                let [<Literal>] Is4 = "is-offset-4-mobile"
                let [<Literal>] Is5 = "is-offset-5-mobile"
                let [<Literal>] Is6 = "is-offset-6-mobile"
                let [<Literal>] Is7 = "is-offset-7-mobile"
                let [<Literal>] Is8 = "is-offset-8-mobile"
                let [<Literal>] Is9 = "is-offset-9-mobile"
                let [<Literal>] Is10 = "is-offset-10-mobile"
                let [<Literal>] Is11 = "is-offset-11-mobile"
                let [<Literal>] IsNarrow = "is-offset-narrow-mobile"
                let [<Literal>] IsFull = "is-offset-full-mobile"
                let [<Literal>] IsOneFifth = "is-offset-one-fifth-mobile"
                let [<Literal>] IsTwoFifths = "is-offset-two-fifths-mobile"
                let [<Literal>] IsThreeFifths = "is-offset-three-fifths-mobile"
                let [<Literal>] IsFourFifths = "is-offset-four-fifths-mobile"

        module Tablet =
            module Width =
                let [<Literal>] IsOneQuarter = "is-one-quarter-tablet"
                let [<Literal>] IsOneThird = "is-one-third-tablet"
                let [<Literal>] IsHalf = "is-half-tablet"
                let [<Literal>] IsTwoThirds = "is-two-third-tablet"
                let [<Literal>] IsThreeQuarters = "is-three-quarters-tablet"
                let [<Literal>] Is1 = "is-1-tablet"
                let [<Literal>] Is2 = "is-2-tablet"
                let [<Literal>] Is3 = "is-3-tablet"
                let [<Literal>] Is4 = "is-4-tablet"
                let [<Literal>] Is5 = "is-5-tablet"
                let [<Literal>] Is6 = "is-6-tablet"
                let [<Literal>] Is7 = "is-7-tablet"
                let [<Literal>] Is8 = "is-8-tablet"
                let [<Literal>] Is9 = "is-9-tablet"
                let [<Literal>] Is10 = "is-10-tablet"
                let [<Literal>] Is11 = "is-11-tablet"
                let [<Literal>] IsNarrow = "is-narrow-tablet"
                let [<Literal>] IsFull = "is-full-tablet"
                let [<Literal>] IsOneFifth = "is-one-fifth-tablet"
                let [<Literal>] IsTwoFifths = "is-two-fifths-tablet"
                let [<Literal>] IsThreeFifths = "is-three-fifths-tablet"
                let [<Literal>] IsFourFifths = "is-four-fifths-tablet"

            module Offset =
                let [<Literal>] IsOneQuarter = "is-offset-one-quarter-tablet"
                let [<Literal>] IsOneThird = "is-offset-one-third-tablet"
                let [<Literal>] IsHalf = "is-offset-half-tablet"
                let [<Literal>] IsTwoThirds = "is-offset-two-third-tablet"
                let [<Literal>] IsThreeQuarters = "is-offset-three-quarters-tablet"
                let [<Literal>] Is1 = "is-offset-1-tablet"
                let [<Literal>] Is2 = "is-offset-2-tablet"
                let [<Literal>] Is3 = "is-offset-3-tablet"
                let [<Literal>] Is4 = "is-offset-4-tablet"
                let [<Literal>] Is5 = "is-offset-5-tablet"
                let [<Literal>] Is6 = "is-offset-6-tablet"
                let [<Literal>] Is7 = "is-offset-7-tablet"
                let [<Literal>] Is8 = "is-offset-8-tablet"
                let [<Literal>] Is9 = "is-offset-9-tablet"
                let [<Literal>] Is10 = "is-offset-10-tablet"
                let [<Literal>] Is11 = "is-offset-11-tablet"
                let [<Literal>] IsNarrow = "is-offset-narrow-tablet"
                let [<Literal>] IsFull = "is-offset-full-tablet"
                let [<Literal>] IsOneFifth = "is-offset-one-fifth-tablet"
                let [<Literal>] IsTwoFifths = "is-offset-two-fifths-tablet"
                let [<Literal>] IsThreeFifths = "is-offset-three-fifths-tablet"
                let [<Literal>] IsFourFifths = "is-offset-four-fifths-tablet"

        module WideScreen =
            module Width =
                let [<Literal>] IsOneQuarter = "is-one-quarter-widescreen"
                let [<Literal>] IsOneThird = "is-one-third-widescreen"
                let [<Literal>] IsHalf = "is-half-widescreen"
                let [<Literal>] IsTwoThirds = "is-two-third-widescreen"
                let [<Literal>] IsThreeQuarters = "is-three-quarters-widescreen"
                let [<Literal>] Is1 = "is-1-widescreen"
                let [<Literal>] Is2 = "is-2-widescreen"
                let [<Literal>] Is3 = "is-3-widescreen"
                let [<Literal>] Is4 = "is-4-widescreen"
                let [<Literal>] Is5 = "is-5-widescreen"
                let [<Literal>] Is6 = "is-6-widescreen"
                let [<Literal>] Is7 = "is-7-widescreen"
                let [<Literal>] Is8 = "is-8-widescreen"
                let [<Literal>] Is9 = "is-9-widescreen"
                let [<Literal>] Is10 = "is-10-widescreen"
                let [<Literal>] Is11 = "is-11-widescreen"
                let [<Literal>] IsNarrow = "is-narrow-widescreen"
                let [<Literal>] IsFull = "is-full-widescreen"
                let [<Literal>] IsOneFifth = "is-one-fifth-widescreen"
                let [<Literal>] IsTwoFifths = "is-two-fifths-widescreen"
                let [<Literal>] IsThreeFifths = "is-three-fifths-widescreen"
                let [<Literal>] IsFourFifths = "is-four-fifths-widescreen"

            module Offset =
                let [<Literal>] IsOneQuarter = "is-offset-one-quarter-widescreen"
                let [<Literal>] IsOneThird = "is-offset-one-third-widescreen"
                let [<Literal>] IsHalf = "is-offset-half-widescreen"
                let [<Literal>] IsTwoThirds = "is-offset-two-third-widescreen"
                let [<Literal>] IsThreeQuarters = "is-offset-three-quarters-widescreen"
                let [<Literal>] Is1 = "is-offset-1-widescreen"
                let [<Literal>] Is2 = "is-offset-2-widescreen"
                let [<Literal>] Is3 = "is-offset-3-widescreen"
                let [<Literal>] Is4 = "is-offset-4-widescreen"
                let [<Literal>] Is5 = "is-offset-5-widescreen"
                let [<Literal>] Is6 = "is-offset-6-widescreen"
                let [<Literal>] Is7 = "is-offset-7-widescreen"
                let [<Literal>] Is8 = "is-offset-8-widescreen"
                let [<Literal>] Is9 = "is-offset-9-widescreen"
                let [<Literal>] Is10 = "is-offset-10-widescreen"
                let [<Literal>] Is11 = "is-offset-11-widescreen"
                let [<Literal>] IsNarrow = "is-offset-narrow-widescreen"
                let [<Literal>] IsFull = "is-offset-full-widescreen"
                let [<Literal>] IsOneFifth = "is-offset-one-fifth-widescreen"
                let [<Literal>] IsTwoFifths = "is-offset-two-fifths-widescreen"
                let [<Literal>] IsThreeFifths = "is-offset-three-fifths-widescreen"
                let [<Literal>] IsFourFifths = "is-offset-four-fifths-widescreen"




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
        | IsOneFifth
        | IsTwoFifths
        | IsThreeFifths
        | IsFourFifths

    type IScreen =
        | All
        | Desktop
        | Tablet
        | Mobile
        | WideScreen

    type Option =
        /// Configure the width of the column. You can configure the display and size
        /// Example: Column.Width (Column.Desktop, Column.Is6)
        /// Becomde: `is-6-desktop`
        | Width of IScreen * ISize
        /// Configure the offset of the column. You can configure the display and offset size
        /// Example: Column.Offset (Column.Desktop, Column.Is6)
        /// Becomde: `is-offset-6-desktop`
        | Offset of IScreen * ISize
        | CustomClass of string
        | Props of IHTMLProp list

    let internal ofWidth =
        function
        | All, size ->
            match size with
            | IsOneQuarter -> Classes.All.Width.IsOneQuarter
            | IsOneThird -> Classes.All.Width.IsOneThird
            | IsHalf -> Classes.All.Width.IsHalf
            | IsTwoThirds -> Classes.All.Width.IsTwoThirds
            | IsThreeQuarters -> Classes.All.Width.IsThreeQuarters
            | Is1 -> Classes.All.Width.Is1
            | Is2 -> Classes.All.Width.Is2
            | Is3 -> Classes.All.Width.Is3
            | Is4 -> Classes.All.Width.Is4
            | Is5 -> Classes.All.Width.Is5
            | Is6 -> Classes.All.Width.Is6
            | Is7 -> Classes.All.Width.Is7
            | Is8 -> Classes.All.Width.Is8
            | Is9 -> Classes.All.Width.Is9
            | Is10 -> Classes.All.Width.Is10
            | Is11 -> Classes.All.Width.Is11
            | IsNarrow -> Classes.All.Width.IsNarrow
            | IsFull -> Classes.All.Width.IsFull
            | IsOneFifth -> Classes.All.Width.IsOneFifth
            | IsTwoFifths -> Classes.All.Width.IsTwoFifths
            | IsThreeFifths -> Classes.All.Width.IsThreeFifths
            | IsFourFifths -> Classes.All.Width.IsFourFifths
        | Desktop, size ->
            match size with
            | IsOneQuarter -> Classes.Desktop.Width.IsOneQuarter
            | IsOneThird -> Classes.Desktop.Width.IsOneThird
            | IsHalf -> Classes.Desktop.Width.IsHalf
            | IsTwoThirds -> Classes.Desktop.Width.IsTwoThirds
            | IsThreeQuarters -> Classes.Desktop.Width.IsThreeQuarters
            | Is1 -> Classes.Desktop.Width.Is1
            | Is2 -> Classes.Desktop.Width.Is2
            | Is3 -> Classes.Desktop.Width.Is3
            | Is4 -> Classes.Desktop.Width.Is4
            | Is5 -> Classes.Desktop.Width.Is5
            | Is6 -> Classes.Desktop.Width.Is6
            | Is7 -> Classes.Desktop.Width.Is7
            | Is8 -> Classes.Desktop.Width.Is8
            | Is9 -> Classes.Desktop.Width.Is9
            | Is10 -> Classes.Desktop.Width.Is10
            | Is11 -> Classes.Desktop.Width.Is11
            | IsNarrow -> Classes.Desktop.Width.IsNarrow
            | IsFull -> Classes.Desktop.Width.IsFull
            | IsOneFifth -> Classes.Desktop.Width.IsOneFifth
            | IsTwoFifths -> Classes.Desktop.Width.IsTwoFifths
            | IsThreeFifths -> Classes.Desktop.Width.IsThreeFifths
            | IsFourFifths -> Classes.Desktop.Width.IsFourFifths
        | Tablet, size ->
            match size with
            | IsOneQuarter -> Classes.Tablet.Width.IsOneQuarter
            | IsOneThird -> Classes.Tablet.Width.IsOneThird
            | IsHalf -> Classes.Tablet.Width.IsHalf
            | IsTwoThirds -> Classes.Tablet.Width.IsTwoThirds
            | IsThreeQuarters -> Classes.Tablet.Width.IsThreeQuarters
            | Is1 -> Classes.Tablet.Width.Is1
            | Is2 -> Classes.Tablet.Width.Is2
            | Is3 -> Classes.Tablet.Width.Is3
            | Is4 -> Classes.Tablet.Width.Is4
            | Is5 -> Classes.Tablet.Width.Is5
            | Is6 -> Classes.Tablet.Width.Is6
            | Is7 -> Classes.Tablet.Width.Is7
            | Is8 -> Classes.Tablet.Width.Is8
            | Is9 -> Classes.Tablet.Width.Is9
            | Is10 -> Classes.Tablet.Width.Is10
            | Is11 -> Classes.Tablet.Width.Is11
            | IsNarrow -> Classes.Tablet.Width.IsNarrow
            | IsFull -> Classes.Tablet.Width.IsFull
            | IsOneFifth -> Classes.Tablet.Width.IsOneFifth
            | IsTwoFifths -> Classes.Tablet.Width.IsTwoFifths
            | IsThreeFifths -> Classes.Tablet.Width.IsThreeFifths
            | IsFourFifths -> Classes.Tablet.Width.IsFourFifths
        | Mobile, size ->
            match size with
            | IsOneQuarter -> Classes.Mobile.Width.IsOneQuarter
            | IsOneThird -> Classes.Mobile.Width.IsOneThird
            | IsHalf -> Classes.Mobile.Width.IsHalf
            | IsTwoThirds -> Classes.Mobile.Width.IsTwoThirds
            | IsThreeQuarters -> Classes.Mobile.Width.IsThreeQuarters
            | Is1 -> Classes.Mobile.Width.Is1
            | Is2 -> Classes.Mobile.Width.Is2
            | Is3 -> Classes.Mobile.Width.Is3
            | Is4 -> Classes.Mobile.Width.Is4
            | Is5 -> Classes.Mobile.Width.Is5
            | Is6 -> Classes.Mobile.Width.Is6
            | Is7 -> Classes.Mobile.Width.Is7
            | Is8 -> Classes.Mobile.Width.Is8
            | Is9 -> Classes.Mobile.Width.Is9
            | Is10 -> Classes.Mobile.Width.Is10
            | Is11 -> Classes.Mobile.Width.Is11
            | IsNarrow -> Classes.Mobile.Width.IsNarrow
            | IsFull -> Classes.Mobile.Width.IsFull
            | IsOneFifth -> Classes.Mobile.Width.IsOneFifth
            | IsTwoFifths -> Classes.Mobile.Width.IsTwoFifths
            | IsThreeFifths -> Classes.Mobile.Width.IsThreeFifths
            | IsFourFifths -> Classes.Mobile.Width.IsFourFifths
        | WideScreen, size ->
            match size with
            | IsOneQuarter -> Classes.WideScreen.Width.IsOneQuarter
            | IsOneThird -> Classes.WideScreen.Width.IsOneThird
            | IsHalf -> Classes.WideScreen.Width.IsHalf
            | IsTwoThirds -> Classes.WideScreen.Width.IsTwoThirds
            | IsThreeQuarters -> Classes.WideScreen.Width.IsThreeQuarters
            | Is1 -> Classes.WideScreen.Width.Is1
            | Is2 -> Classes.WideScreen.Width.Is2
            | Is3 -> Classes.WideScreen.Width.Is3
            | Is4 -> Classes.WideScreen.Width.Is4
            | Is5 -> Classes.WideScreen.Width.Is5
            | Is6 -> Classes.WideScreen.Width.Is6
            | Is7 -> Classes.WideScreen.Width.Is7
            | Is8 -> Classes.WideScreen.Width.Is8
            | Is9 -> Classes.WideScreen.Width.Is9
            | Is10 -> Classes.WideScreen.Width.Is10
            | Is11 -> Classes.WideScreen.Width.Is11
            | IsNarrow -> Classes.WideScreen.Width.IsNarrow
            | IsFull -> Classes.WideScreen.Width.IsFull
            | IsOneFifth -> Classes.WideScreen.Width.IsOneFifth
            | IsTwoFifths -> Classes.WideScreen.Width.IsTwoFifths
            | IsThreeFifths -> Classes.WideScreen.Width.IsThreeFifths
            | IsFourFifths -> Classes.WideScreen.Width.IsFourFifths

    let internal ofOffset =
        function
        | All, offset ->
            match offset with
            | IsOneQuarter -> Classes.All.Offset.IsOneQuarter
            | IsOneThird -> Classes.All.Offset.IsOneThird
            | IsHalf -> Classes.All.Offset.IsHalf
            | IsTwoThirds -> Classes.All.Offset.IsTwoThirds
            | IsThreeQuarters -> Classes.All.Offset.IsThreeQuarters
            | Is1 -> Classes.All.Offset.Is1
            | Is2 -> Classes.All.Offset.Is2
            | Is3 -> Classes.All.Offset.Is3
            | Is4 -> Classes.All.Offset.Is4
            | Is5 -> Classes.All.Offset.Is5
            | Is6 -> Classes.All.Offset.Is6
            | Is7 -> Classes.All.Offset.Is7
            | Is8 -> Classes.All.Offset.Is8
            | Is9 -> Classes.All.Offset.Is9
            | Is10 -> Classes.All.Offset.Is10
            | Is11 -> Classes.All.Offset.Is11
            | IsNarrow -> Classes.All.Offset.IsNarrow
            | IsFull -> Classes.All.Offset.IsFull
            | IsOneFifth -> Classes.All.Offset.IsOneFifth
            | IsTwoFifths -> Classes.All.Offset.IsTwoFifths
            | IsThreeFifths -> Classes.All.Offset.IsThreeFifths
            | IsFourFifths -> Classes.All.Offset.IsFourFifths
        | Desktop, offset ->
            match offset with
            | IsOneQuarter -> Classes.Desktop.Offset.IsOneQuarter
            | IsOneThird -> Classes.Desktop.Offset.IsOneThird
            | IsHalf -> Classes.Desktop.Offset.IsHalf
            | IsTwoThirds -> Classes.Desktop.Offset.IsTwoThirds
            | IsThreeQuarters -> Classes.Desktop.Offset.IsThreeQuarters
            | Is1 -> Classes.Desktop.Offset.Is1
            | Is2 -> Classes.Desktop.Offset.Is2
            | Is3 -> Classes.Desktop.Offset.Is3
            | Is4 -> Classes.Desktop.Offset.Is4
            | Is5 -> Classes.Desktop.Offset.Is5
            | Is6 -> Classes.Desktop.Offset.Is6
            | Is7 -> Classes.Desktop.Offset.Is7
            | Is8 -> Classes.Desktop.Offset.Is8
            | Is9 -> Classes.Desktop.Offset.Is9
            | Is10 -> Classes.Desktop.Offset.Is10
            | Is11 -> Classes.Desktop.Offset.Is11
            | IsNarrow -> Classes.Desktop.Offset.IsNarrow
            | IsFull -> Classes.Desktop.Offset.IsFull
            | IsOneFifth -> Classes.Desktop.Offset.IsOneFifth
            | IsTwoFifths -> Classes.Desktop.Offset.IsTwoFifths
            | IsThreeFifths -> Classes.Desktop.Offset.IsThreeFifths
            | IsFourFifths -> Classes.Desktop.Offset.IsFourFifths
        | Tablet, offset ->
            match offset with
            | IsOneQuarter -> Classes.Tablet.Offset.IsOneQuarter
            | IsOneThird -> Classes.Tablet.Offset.IsOneThird
            | IsHalf -> Classes.Tablet.Offset.IsHalf
            | IsTwoThirds -> Classes.Tablet.Offset.IsTwoThirds
            | IsThreeQuarters -> Classes.Tablet.Offset.IsThreeQuarters
            | Is1 -> Classes.Tablet.Offset.Is1
            | Is2 -> Classes.Tablet.Offset.Is2
            | Is3 -> Classes.Tablet.Offset.Is3
            | Is4 -> Classes.Tablet.Offset.Is4
            | Is5 -> Classes.Tablet.Offset.Is5
            | Is6 -> Classes.Tablet.Offset.Is6
            | Is7 -> Classes.Tablet.Offset.Is7
            | Is8 -> Classes.Tablet.Offset.Is8
            | Is9 -> Classes.Tablet.Offset.Is9
            | Is10 -> Classes.Tablet.Offset.Is10
            | Is11 -> Classes.Tablet.Offset.Is11
            | IsNarrow -> Classes.Tablet.Offset.IsNarrow
            | IsFull -> Classes.Tablet.Offset.IsFull
            | IsOneFifth -> Classes.Tablet.Offset.IsOneFifth
            | IsTwoFifths -> Classes.Tablet.Offset.IsTwoFifths
            | IsThreeFifths -> Classes.Tablet.Offset.IsThreeFifths
            | IsFourFifths -> Classes.Tablet.Offset.IsFourFifths
        | Mobile, offset ->
            match offset with
            | IsOneQuarter -> Classes.Mobile.Offset.IsOneQuarter
            | IsOneThird -> Classes.Mobile.Offset.IsOneThird
            | IsHalf -> Classes.Mobile.Offset.IsHalf
            | IsTwoThirds -> Classes.Mobile.Offset.IsTwoThirds
            | IsThreeQuarters -> Classes.Mobile.Offset.IsThreeQuarters
            | Is1 -> Classes.Mobile.Offset.Is1
            | Is2 -> Classes.Mobile.Offset.Is2
            | Is3 -> Classes.Mobile.Offset.Is3
            | Is4 -> Classes.Mobile.Offset.Is4
            | Is5 -> Classes.Mobile.Offset.Is5
            | Is6 -> Classes.Mobile.Offset.Is6
            | Is7 -> Classes.Mobile.Offset.Is7
            | Is8 -> Classes.Mobile.Offset.Is8
            | Is9 -> Classes.Mobile.Offset.Is9
            | Is10 -> Classes.Mobile.Offset.Is10
            | Is11 -> Classes.Mobile.Offset.Is11
            | IsNarrow -> Classes.Mobile.Offset.IsNarrow
            | IsFull -> Classes.Mobile.Offset.IsFull
            | IsOneFifth -> Classes.Mobile.Offset.IsOneFifth
            | IsTwoFifths -> Classes.Mobile.Offset.IsTwoFifths
            | IsThreeFifths -> Classes.Mobile.Offset.IsThreeFifths
            | IsFourFifths -> Classes.Mobile.Offset.IsFourFifths
        | WideScreen, offset ->
            match offset with
            | IsOneQuarter -> Classes.WideScreen.Offset.IsOneQuarter
            | IsOneThird -> Classes.WideScreen.Offset.IsOneThird
            | IsHalf -> Classes.WideScreen.Offset.IsHalf
            | IsTwoThirds -> Classes.WideScreen.Offset.IsTwoThirds
            | IsThreeQuarters -> Classes.WideScreen.Offset.IsThreeQuarters
            | Is1 -> Classes.WideScreen.Offset.Is1
            | Is2 -> Classes.WideScreen.Offset.Is2
            | Is3 -> Classes.WideScreen.Offset.Is3
            | Is4 -> Classes.WideScreen.Offset.Is4
            | Is5 -> Classes.WideScreen.Offset.Is5
            | Is6 -> Classes.WideScreen.Offset.Is6
            | Is7 -> Classes.WideScreen.Offset.Is7
            | Is8 -> Classes.WideScreen.Offset.Is8
            | Is9 -> Classes.WideScreen.Offset.Is9
            | Is10 -> Classes.WideScreen.Offset.Is10
            | Is11 -> Classes.WideScreen.Offset.Is11
            | IsNarrow -> Classes.WideScreen.Offset.IsNarrow
            | IsFull -> Classes.WideScreen.Offset.IsFull
            | IsOneFifth -> Classes.WideScreen.Offset.IsOneFifth
            | IsTwoFifths -> Classes.WideScreen.Offset.IsTwoFifths
            | IsThreeFifths -> Classes.WideScreen.Offset.IsThreeFifths
            | IsFourFifths -> Classes.WideScreen.Offset.IsFourFifths

    type internal Options =
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

    /// Generate <div class="column"></div>
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
        let classes = Helpers.classes
                        Classes.Container
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
                          opts.CustomClass ]
                        [ ]
        div (classes::opts.Props) children
