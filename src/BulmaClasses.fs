namespace Elmish.Bulma

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

    and Box =
        { Container : string }

    and Button =
        { Container : string
          Size : StandardSize
          Color : LevelAndColor
          State : ButtonState
          Styles : ButtonStyles }

    and ButtonState =
        { IsHovered : string
          IsFocused : string
          IsActive : string
          IsLoading : string }

    and ButtonStyles =
        { IsLink : string
          IsOutlined : string
          IsInverted : string }

    and Content =
        { Container : string
          Size : StandardSize }

    and Control =
        { Container : string
          HasIcon : ControlHasIcon
          State : ControlState }

    and ControlHasIcon =
        { Left : string
          Right : string }

    and ControlState =
        { IsLoading : string }

    and Delete =
        { Container : string
          Size : StandardSize }

    and Field =
        { Container : string
          Label : string
          Body : string
          HasAddons : FieldHasAddons
          IsGrouped : FieldIsGrouped
          Layout : FieldLayout }

    and FieldHasAddons =
        { Left : string
          Centered : string
          Right : string
          FullWidh : string }

    and FieldIsGrouped =
        { Left : string
          Centered : string
          Right : string }

    and FieldLayout =
        { IsHorizontal : string }

    and Columns =
        { Container : string
          Column : Column
          Alignment : ColumnsAlignment
          Spacing : ColumnsSpacing
          Display : ColumnsDisplay }

    and Column =
        { Container : string
          Width : ColumnWidth
          Offset : ColumnOffset }

    and ColumnWidth =
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
          IsNarrow : string }

    and ColumnOffset =
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
          IsNarrow : string }

    and ColumnsAlignment =
        { IsCentered : string
          IsVCentered : string }

    and ColumnsSpacing =
        { IsMultiline : string
          IsGapless : string
          IsGrid : string }

    and ColumnsDisplay =
        { OnMobile : string
          OnlyDesktop : string }

    and Icon =
        { Container : string
          Position : IconPosition
          Size : StandardSize }

    and IconPosition =
        { Left : string
          Right : string }

    and Input =
        { Container : string
          Display : InputDisplay
          Size : StandardSize
          State : InputState
          Color : LevelAndColor
          Addon : InputAddon }

    and InputDisplay =
        { IsInline : string }

    and InputState =
        { IsHovered : string
          IsFocused : string
          IsActive : string
          IsLoading : string }

    and InputAddon =
        { IsExpanded : string }

    and Image =
        { Container : string
          Size : ImageSize
          Ratio : ImageRatio }

    and ImageSize =
        { Is16x16 : string
          Is24x24 : string
          Is32x32 : string
          Is48x48 : string
          Is64x64 : string
          Is96x96 : string
          Is128x128 : string }

    and ImageRatio =
        { IsSquare : string
          Is1by1 : string
          Is4by3 : string
          Is3by2 : string
          Is16by9 : string
          Is2by1 : string }

    and Heading =
        { Title : string
          Subtitle : string
          Size : HeadingSize
          Spacing : HeadingSpacing }

    and HeadingSize =
        { Is1 : string
          Is2 : string
          Is3 : string
          Is4 : string
          Is5 : string
          Is6 : string }

    and HeadingSpacing =
        { IsNormal : string }

    and Label =
        { Container : string
          Size : StandardSize }

    and Modifiers =
        { Size : StandardSize
          Color : LevelAndColor }

    and Progress =
        { Container : string
          Size : StandardSize
          Color : LevelAndColor }

    and Table =
        { Container : string
          Row : TableRow
          Style : TableStyle
          Spacing : TableSpacing }

    and TableRow =
        { State : TableRowState }

    and TableRowState =
        { IsSelected : string }

    and TableStyle =
        { IsBordered : string
          IsStripped : string }

    and TableSpacing =
        { IsNarrow : string }

    and Tag =
        { Container : string
          Size : TagSize
          Color : LevelAndColor }

    and TagSize =
        { IsMedium : string
          IsLarge : string }

    and Bulma =
        { Modifiers : Modifiers
          Box : Box
          Button : Button
          Columns : Columns
          Content : Content
          Control : Control
          Delete : Delete
          Field : Field
          Heading : Heading
          Label : Label
          Progress : Progress
          Icon : Icon
          Image : Image
          Input : Input
          Table : Table
          Tag : Tag }

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

    let box = { Container = "box" }

    let button : Button =
        { Container = "button"
          Size = standardSize
          Color = levelAndColor
          State =
              { IsHovered = "is-hovered"
                IsFocused = "is-focus"
                IsActive = "is-active"
                IsLoading = "is-loading" }
          Styles =
              { IsLink = "is-link"
                IsOutlined = "is-outlined"
                IsInverted = "is-inverted" } }

    let content : Content =
        { Container = "content"
          Size = standardSize }

    let control : Control =
        { Container = "control"
          HasIcon =
              { Left = "has-icons-left"
                Right = "has-icons-right" }
          State = { IsLoading = "is-loading" } }

    let columns : Columns =
        { Container = "columns"
          Column =
            { Container = "column"
              Width =
                { IsOneQuarter = "is-one-quarter"
                  IsOneThird = "is-one-third"
                  IsHalf = "is-harl"
                  IsTwoThirds = "is-two-thirds"
                  IsThreeQuarters = "is-three-quarters"
                  Is1 = "is-1"
                  Is2 = "is-2"
                  Is3 = "is-3"
                  Is4 = "is-4"
                  Is5 = "is-5"
                  Is6 = "is-6"
                  Is7 = "is-7"
                  Is8 = "is-8"
                  Is9 = "is-9"
                  Is10 = "is-10"
                  Is11 = "is-11"
                  IsNarrow = "is-narrow" }
              Offset =
                { IsOneQuarter = "is-offset-one-quarter"
                  IsOneThird = "is-offset-one-third"
                  IsHalf = "is-offset-harl"
                  IsTwoThirds = "is-offset-two-thirds"
                  IsThreeQuarters = "is-offset-three-quarters"
                  Is1 = "is-offset-1"
                  Is2 = "is-offset-2"
                  Is3 = "is-offset-3"
                  Is4 = "is-offset-4"
                  Is5 = "is-offset-5"
                  Is6 = "is-offset-6"
                  Is7 = "is-offset-7"
                  Is8 = "is-offset-8"
                  Is9 = "is-offset-9"
                  Is10 = "is-offset-10"
                  Is11 = "is-offset-11"
                  IsNarrow = "is-offset-narrow" }

              }
          Alignment =
            { IsCentered = "is-centered"
              IsVCentered = "is-vcentered" }
          Spacing =
            { IsMultiline = "is-multiline"
              IsGapless = "is-gapless"
              IsGrid = "is-grid" }
          Display =
            { OnMobile = "on-mobile"
              OnlyDesktop = "only-desktop" } }

    let delete : Delete =
        { Container = "delete"
          Size = standardSize }

    let field : Field =
        { Container = "field"
          Label = "field-label"
          Body = "field-body"
          HasAddons =
              { Left = "has-addons"
                Centered = "has-addons-centered"
                Right = "has-addons-right"
                FullWidh = "has-addons-fullwidth" }
          IsGrouped =
              { Left = "is-grouped"
                Centered = "is-grouped-centered"
                Right = "is-grouped-right" }
          Layout = { IsHorizontal = "is-horizontal" } }

    let icon : Icon =
        { Container = "icon"
          Position =
              { Left = "is-left"
                Right = "is-right" }
          Size = standardSize }

    let input : Input =
        { Container = "input"
          Display = { IsInline = "is-inline" }
          Size = standardSize
          State =
              { IsHovered = "is-hovered"
                IsFocused = "is-focus"
                IsActive = "is-active"
                IsLoading = "is-loading" }
          Color = levelAndColor
          Addon = { IsExpanded = "is-expanded" } }

    let image : Image =
        { Container = "image"
          Size =
              { Is16x16 = "is-16x16"
                Is24x24 = "is-24x24"
                Is32x32 = "is-32x32"
                Is48x48 = "is-48x48"
                Is64x64 = "is-64x64"
                Is96x96 = "is-96x96"
                Is128x128 = "is-128x128" }
          Ratio =
              { IsSquare = "is-square"
                Is1by1 = "is-1by1"
                Is4by3 = "is-4by3"
                Is3by2 = "is-3by2"
                Is16by9 = "is-16by9"
                Is2by1 = "is-2by1" } }

    let heading : Heading =
        { Title = "title"
          Subtitle = "subtitle"
          Size =
              { Is1 = "is-1"
                Is2 = "is-2"
                Is3 = "is-3"
                Is4 = "is-4"
                Is5 = "is-5"
                Is6 = "is-6" }
          Spacing = { IsNormal = "is-spaced" } }

    let label : Label =
        { Container = "label"
          Size = standardSize }

    let progress : Progress =
        { Container = "progress"
          Size = standardSize
          Color = levelAndColor }

    let table : Table =
        { Container = "table"
          Row = { State = { IsSelected = "is-selected" } }
          Style =
              { IsBordered = "is-bordered"
                IsStripped = "is-stripped " }
          Spacing = { IsNarrow = "is-narrow" } }

    let tagSize : TagSize =
        { IsMedium = "is-medium"
          IsLarge = "is-large" }

    let tag : Tag =
        { Container = "tag"
          Size = tagSize
          Color = levelAndColor }

    let bulma =
        { Modifiers =
              { Size = standardSize
                Color = levelAndColor }
          Box = box
          Button = button
          Columns = columns
          Content = content
          Control = control
          Delete = delete
          Field = field
          Icon = icon
          Image = image
          Input = input
          Label = label
          Progress = progress
          Heading = heading
          Table = table
          Tag = tag }

    let (++) str1 str2 = str1 + " " + str2
