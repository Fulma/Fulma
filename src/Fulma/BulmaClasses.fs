namespace Fulma

module BulmaClasses =
    type DisplayType =
        { Always : string
          Mobile : string
          Tablet : string
          TabletOnly : string
          Touch : string
          Desktop : string
          DesktopOnly : string
          Widescreen : string }

    let (++) str1 str2 = str1 + " " + str2

    let generateDisplayType prefix =
        { Always = "is-" + prefix + "-touch" ++ "is-" + prefix + "-desktop"
          Mobile = "is-" + prefix + "-mobile"
          Tablet = "is-" + prefix + "-tablet"
          TabletOnly = "is-" + prefix + "-tablet-only"
          Touch = "is-" + prefix + "-touch"
          Desktop = "is-" + prefix + "-desktop"
          DesktopOnly = "is-" + prefix + "-desktop-only"
          Widescreen = "is-" + prefix + "-widescreen" }

    module Bulma =

        module Properties =
            module Float =
                let [<Literal>] IsClearfix = "is-clearfix"
                let [<Literal>] IsPulledLeft = "is-pulled-left"
                let [<Literal>] IsPulledRight = "is-pulled-right"
            module Alignment =
                let [<Literal>] HasTextCentered = "has-text-centered"
                let [<Literal>] HasTextLeft = "has-text-left"
                let [<Literal>] HasTextRight = "has-text-right"
            module Sizing =
                let [<Literal>] IsOverlay = "is-overlay"
                let [<Literal>] IsFullwidth = "is-fullwidth"
                let [<Literal>] IsMarginless = "is-marginless"
                let [<Literal>] IsPaddingless = "is-paddingless"
            module Display =
                let inline IsBlock<'T> = generateDisplayType "block"
                let inline IsFlex<'T> = generateDisplayType "flex"
                let inline IsInline<'T> = generateDisplayType "inline"
                let inline IsInlineBox<'T> = generateDisplayType "inline-block"
                let inline IsInlineFlex<'T> = generateDisplayType "inline-flex"
            module Visibility =
                let inline IsHidden<'T> = generateDisplayType "hidden"
            module Interaction =
                let [<Literal>] IsUnselectable = "is-unselectable"
