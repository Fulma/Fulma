namespace Fulma

module BulmaClasses =
    type StandardSize =
        { IsSmall : string
          IsMedium : string
          IsLarge : string }

    and LevelAndColor =
        { IsBlack : string
          IsDark : string
          IsLight : string
          IsWhite : string
          IsPrimary : string
          IsInfo : string
          IsSuccess : string
          IsWarning : string
          IsDanger : string }

    and GenericIsActiveState =
        { IsActive : string }

    and GenericColumnSize =
        { IsOneQuarter : string
          IsOneThird : string
          IsHalf : string
          IsTwoThirds : string
          IsThreeQuarters : string
          Is1 : string
          Is2 : string
          Is3 : string
          Is4 : string
          Is5 : string
          Is6 : string
          Is7 : string
          Is8 : string
          Is9 : string
          Is10 : string
          Is11 : string
          IsNarrow : string
          IsFull : string }


    and DisplayType =
        { Always : string
          Mobile : string
          Tablet : string
          TabletOnly : string
          Touch : string
          Desktop : string
          DesktopOnly : string
          Widescreen : string }

    let (++) str1 str2 = str1 + " " + str2

    let standardSize =
        { IsSmall = "is-small"
          IsMedium = "is-medium"
          IsLarge = "is-large " }

    let levelAndColor =
        { IsBlack = "is-black"
          IsDark = "is-dark"
          IsLight = "is-light"
          IsWhite = "is-white"
          IsPrimary = "is-primary"
          IsInfo = "is-info"
          IsSuccess = "is-success"
          IsWarning = "is-warning"
          IsDanger = "is-danger" }

    let genericIsActiveState : GenericIsActiveState =
        { IsActive = "is-active" }


    let generateColumnSize suffix =
        { IsOneQuarter = "is-one-quarter" + suffix
          IsOneThird = "is-one-third" + suffix
          IsHalf = "is-half" + suffix
          IsTwoThirds = "is-two-third + suffixs"
          IsThreeQuarters = "is-three + suffix-quarters"
          Is1 = "is-1" + suffix
          Is2 = "is-2" + suffix
          Is3 = "is-3" + suffix
          Is4 = "is-4" + suffix
          Is5 = "is-5" + suffix
          Is6 = "is-6" + suffix
          Is7 = "is-7" + suffix
          Is8 = "is-8" + suffix
          Is9 = "is-9" + suffix
          Is10 = "is-10" + suffix
          Is11 = "is-11" + suffix
          IsNarrow = "is-narrow" + suffix
          IsFull = "is-full" + suffix }

    let generateColumnOffset suffix =
        { IsOneQuarter = "is-offset-one-quarter" + suffix
          IsOneThird = "is-offset-one-third" + suffix
          IsHalf = "is-offset-half" + suffix
          IsTwoThirds = "is-offset-two-thirds" + suffix
          IsThreeQuarters = "is-offset-three-qua + suffixrters"
          Is1 = "is-offset-1" + suffix
          Is2 = "is-offset-2" + suffix
          Is3 = "is-offset-3" + suffix
          Is4 = "is-offset-4" + suffix
          Is5 = "is-offset-5" + suffix
          Is6 = "is-offset-6" + suffix
          Is7 = "is-offset-7" + suffix
          Is8 = "is-offset-8" + suffix
          Is9 = "is-offset-9" + suffix
          Is10 = "is-offset-10" + suffix
          Is11 = "is-offset-11" + suffix
          IsNarrow = "is-offset-narrow" + suffix
          IsFull = "is-full" + suffix }

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
        module Modifiers =
              let Size = standardSize
              let Color = levelAndColor
        module Box =
            let [<Literal>] Container = "box"
        module Button =
            let [<Literal>] Container = "button"
            module Size =
                let [<Literal>] IsSmall = "is-small"
                let [<Literal>] IsMedium = "is-medium"
                let [<Literal>] IsLarge = "is-large "
                let [<Literal>] IsFullwidth = "is-fullwidth"
            let Color = levelAndColor
            module State =
                  let [<Literal>] IsHovered = "is-hovered"
                  let [<Literal>] IsFocused = "is-focus"
                  let [<Literal>] IsActive = "is-active"
                  let [<Literal>] IsLoading = "is-loading"
            module Styles =
                let [<Literal>] IsLink = "is-link"
                let [<Literal>] IsOutlined = "is-outlined"
                let [<Literal>] IsInverted = "is-inverted"

        module Breadcrumb =

            let [<Literal>] Container = "breadcrumb"
            module Alignment =
                let [<Literal>] IsCentered = "is-centered"
                let [<Literal>] IsRight = "is-right"
            module Separator =
                /// Alias for: has-arrow-separator
                let [<Literal>] Arrow = "has-arrow-separator"
                /// Alias for: has-bullet-separator
                let [<Literal>] Bullet = "has-bullet-separator"
                /// Alias for: has-dot-separator
                let [<Literal>] Dot = "has-dot-separator"
                /// Alias for: has-succeeds-separator
                let [<Literal>] Succeeds = "has-succeeds-separator"
            module State =
                let [<Literal>] IsActive = "is-active"
            let Size = standardSize

        module Card =
            let [<Literal>] Container = "card"
            module Header =
                let [<Literal>] Container = "card-header"
                let [<Literal>] Title = "card-header-title"
                let [<Literal>] Icon ="card-header-icon"
            let [<Literal>] Image = "card-image"
            let [<Literal>] Content = "card-content"
            module Footer =
                let [<Literal>] Container = "card-footer"
                let [<Literal>] Item = "card-footer-item"

        module Content =
            let [<Literal>] Container = "content"
            let Size = standardSize

        module Control =
            let [<Literal>] Container = "control"
            module HasIcon =
                let [<Literal>] Left = "has-icons-left"
                let [<Literal>] Right = "has-icons-right"
            module State =
                let [<Literal>] IsLoading = "is-loading"

        module Delete  =
            let [<Literal>] Container = "delete"
            let Size = standardSize

        module Field =
            let [<Literal>] Container = "field"
            let [<Literal>] Label = "field-label"
            let [<Literal>] Body = "field-body"
            module HasAddons =
                  let [<Literal>] Left = "has-addons"
                  let [<Literal>] Centered = "has-addons-centered"
                  let [<Literal>] Right = "has-addons-right"
                  let [<Literal>] FullWidh = "has-addons-fullwidth"
            module IsGrouped =
                  let [<Literal>] Left = "is-grouped"
                  let [<Literal>] Centered = "is-grouped-centered"
                  let [<Literal>] Right = "is-grouped-right"
            module Layout =
                let [<Literal>] IsHorizontal = "is-horizontal"

        module Grid =
            module Columns =
                let [<Literal>] Container = "columns"
                module Alignment =
                    let [<Literal>] IsCentered = "is-centered"
                    let [<Literal>] IsVCentered = "is-vcentered"
                module Spacing =
                    let [<Literal>] IsMultiline = "is-multiline"
                    let [<Literal>] IsGapless = "is-gapless"
                    let [<Literal>] IsGrid = "is-grid"
                module Display =
                    let [<Literal>] OnMobile = "on-mobile"
                    let [<Literal>] OnlyDesktop = "only-desktop"
            module Column =
                let [<Literal>] Container = "column"
                let Width = generateColumnSize ""
                let Offset = generateColumnOffset ""
                module Desktop =
                    let Width = generateColumnSize "-desktop"
                    let Offset = generateColumnOffset "-desktop"
                module Mobile =
                    let Width = generateColumnSize "-mobile"
                    let Offset = generateColumnOffset "-mobule"
                module Tablet =
                    let Width = generateColumnSize "-tablet"
                    let Offset = generateColumnOffset "-tablet"
                module WideScreen =
                    let Width = generateColumnSize "-widescreen"
                    let Offset = generateColumnOffset "-widescreen"
        module Icon =
            let [<Literal>] Container = "icon"
            module Position =
                  let [<Literal>] Left = "is-left"
                  let [<Literal>] Right = "is-right"
            let Size = standardSize

        module Image =
            let [<Literal>] Container = "image"
            module Size =
                  let [<Literal>] Is16x16 = "is-16x16"
                  let [<Literal>] Is24x24 = "is-24x24"
                  let [<Literal>] Is32x32 = "is-32x32"
                  let [<Literal>] Is48x48 = "is-48x48"
                  let [<Literal>] Is64x64 = "is-64x64"
                  let [<Literal>] Is96x96 = "is-96x96"
                  let [<Literal>] Is128x128 = "is-128x128"
            module Ratio =
                  let [<Literal>] IsSquare = "is-square"
                  let [<Literal>] Is1by1 = "is-1by1"
                  let [<Literal>] Is4by3 = "is-4by3"
                  let [<Literal>] Is3by2 = "is-3by2"
                  let [<Literal>] Is16by9 = "is-16by9"
                  let [<Literal>] Is2by1 = "is-2by1"

        module Input =
            let [<Literal>] Container = "input"
            module Display =
                let [<Literal>] IsInline = "is-inline"
            let Size = standardSize
            module State =
                  let [<Literal>] IsHovered = "is-hovered"
                  let [<Literal>] IsFocused = "is-focus"
                  let [<Literal>] IsActive = "is-active"
                  let [<Literal>] IsLoading = "is-loading"
            let Color = levelAndColor
            module Addon =
                let [<Literal>] IsExpanded = "is-expanded"

        module Label =
            let [<Literal>] Container = "label"
            let Size = standardSize

        module Level =
            let [<Literal>] Container = "level"
            let [<Literal>] Left = "level-left"
            let [<Literal>] Right = "level-right"
            module Item =
                let [<Literal>] Container = "level-item"
                let [<Literal>] HasTextCentered = "has-text-centered"
            module Mobile =
                let [<Literal>] IsHorizontal = "is-mobile"

        module Menu =
            let [<Literal>] Container = "menu"
            let [<Literal>] Label = "menu-label"
            let [<Literal>] List = "menu-list"

            let State = genericIsActiveState

        module Media =
            let [<Literal>] Container = "media"
            let [<Literal>] Left = "media-left"
            let [<Literal>] Right = "media-right"
            let [<Literal>] Content = "media-content"
            module Size =
                  let [<Literal>] IsLarge = "is-large"

        module Message =
            let [<Literal>] Container = "message"
            let [<Literal>] Header = "message-header"
            let [<Literal>] Body = "message-body"
            let Color = levelAndColor

        module Modal =
            let [<Literal>] Container = "modal"
            let [<Literal>] Background = "modal-background"
            let [<Literal>] Content = "modal-content"
            let State = genericIsActiveState

            module Close =
                let [<Literal>] Container = "modal-close"
                let Size = standardSize

            module Card =
                let [<Literal>] Container = "modal-card"
                let [<Literal>] Head = "modal-card-head"
                let [<Literal>] Foot = "modal-card-foot"
                let [<Literal>] Title = "modal-card-title"
                let [<Literal>] Body = "modal-card-body"

        module Navbar =
            let [<Literal>] Container = "navbar"
            let [<Literal>] Brand = "navbar-brand"
            let [<Literal>] Burger = "navbar-burger"
            let [<Literal>] Content = "navbar-content"
            let [<Literal>] Divider = "navbar-divider"
            let [<Literal>] Start = "navbar-start"
            let [<Literal>] End = "navbar-end"
            module Item =
                let [<Literal>] Container = "navbar-item"
                let [<Literal>] IsHoverable = "is-hoverable"
                let State = genericIsActiveState
                module Style =
                    let [<Literal>] HasDropdown = "has-dropdown"
                    let [<Literal>] IsTab = "is-tab"
            module Menu =
                let [<Literal>] Container = "navbar-menu"
                let State = genericIsActiveState
            module Link =
                let [<Literal>] Container = "navbar-link"
                let State = genericIsActiveState
            module Dropdown =
                let [<Literal>] Container = "navbar-dropdown"
                let State = genericIsActiveState
                let [<Literal>] IsBoxed = "is-boxed"
                let [<Literal>] IsRight = "is-right"
            module Style =
                let [<Literal>] HasShadow = "has-shadow"
                let [<Literal>] IsTransparent = "is-transparent"

        module Notification =
            let [<Literal>] Container = "notification"
            let Color = levelAndColor
            module Delete =
                let [<Literal>] Container = "delete"

        module Panel =
            let [<Literal>] Container = "panel"
            let [<Literal>] Heading = "panel-heading"
            module Tabs =
                let [<Literal>] Container = "panel-tabs"
                module Tab =
                    module State =
                        let [<Literal>] IsActive = "is-active"
            module Block =
                let [<Literal>] Container = "panel-block"
                let [<Literal>] Icon = "panel-icon"
                let [<Literal>] List = "panel-list"
                module State =
                    let [<Literal>] IsActive = "is-active"

        module Tabs =
            let [<Literal>] Container = "tabs"
            let State = genericIsActiveState
            let Size = standardSize
            module Alignment =
                let [<Literal>] Center = "is-centered"
                let [<Literal>] Right = "is-right"
            module Style =
                let [<Literal>] IsBoxed = "is-boxed"
                let [<Literal>] IsToggle = "is-toggle"
                let [<Literal>] IsFullwidth = "is-fullwidth"

        module Pagination =
            let [<Literal>] Container = "pagination"
            let [<Literal>] Previous = "pagination-previous"
            let [<Literal>] Next = "pagination-next"
            let [<Literal>] Link = "pagination-link"
            let [<Literal>] Ellipsis = "pagination-ellipsis"
            let [<Literal>] List = "pagination-list"
            let Size = standardSize
            module Alignment =
                let [<Literal>] Center = "is-centered"
                let [<Literal>] Right = "is-right"
            module State =
                let [<Literal>] IsCurrent = "is-current"

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
                let IsBlock = generateDisplayType "block"
                let IsFlex = generateDisplayType "flex"
                let IsInline = generateDisplayType "inline"
                let IsInlineBox = generateDisplayType "inline-block"
                let IsInlineFlex = generateDisplayType "inline-flex"
            module Visibility =
                let IsHidden = generateDisplayType "hidden"
            module Interaction =
                let [<Literal>] IsUnselectable = "is-unselectable"


        module Progress =
            let [<Literal>] Container = "progress"
            let Size = standardSize
            let Color = levelAndColor

        module Heading =
            let [<Literal>] Title = "title"
            let [<Literal>] Subtitle = "subtitle"
            module Size =
              let [<Literal>] Is1 = "is-1"
              let [<Literal>] Is2 = "is-2"
              let [<Literal>] Is3 = "is-3"
              let [<Literal>] Is4 = "is-4"
              let [<Literal>] Is5 = "is-5"
              let [<Literal>] Is6 = "is-6"
            module Spacing =
                let [<Literal>] IsNormal = "is-spaced"

        module Hero =
            let [<Literal>] Container = "hero"
            let [<Literal>] Head = "hero-head"
            let [<Literal>] Body = "hero-body"
            let [<Literal>] Foot = "hero-foot"
            module Video =
                let [<Literal>] Container = "hero-video"
                let [<Literal>] IsTransparent = "is-transparent"
            module Buttons =
                let [<Literal>] Container = "hero-buttons"
            module Style =
                let [<Literal>] IsBold = "is-bold"
            module Size =
                let [<Literal>] IsMedium = "is-medium"
                let [<Literal>] IsLarge = "is-large"
                let [<Literal>] IsHalfHeight = "is-halfheight"
                let [<Literal>] IsFullHeight = "is-fullheight"
            let Color = levelAndColor

        module Table =
            let [<Literal>] Container = "table"
            module Row =
                module State =
                    let [<Literal>] IsSelected = "is-selected"
            module Style =
              let [<Literal>] IsBordered = "is-bordered"
              let [<Literal>] IsStripped = "is-stripped "
            module Spacing =
                let [<Literal>] IsNarrow = "is-narrow"

        module Tag =
          let [<Literal>] Container = "tag"

          module Size =
            let [<Literal>] IsMedium = "is-medium"
            let [<Literal>] IsLarge = "is-large"
          let Color = levelAndColor
