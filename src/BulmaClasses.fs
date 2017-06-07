namespace Elmish.Bulma

module BulmaClasses =

  type StandardSize =
    { isSmall: string
      isMedium: string
      isLarge: string }

  and LevelAndColor =
    { isBlack: string
      isDark: string
      isLight: string
      isWhite: string
      isPrimary: string
      isInfo: string
      isSuccess: string
      isWarning: string
      isDanger: string }

  and Box =
    { container: string }

  and Button =
    { container: string
      size: StandardSize
      color: LevelAndColor
      state: ButtonState
      styles: ButtonStyles }

  and ButtonState =
    { isHovered: string
      isFocused: string
      isActive: string
      isLoading: string }

  and ButtonStyles =
    { isLink: string
      isOutlined: string
      isInverted: string }

  and Content =
    { container: string
      size: StandardSize }

  and Control =
    { container: string
      hasIcon: ControlHasIcon
      state: ControlState }

  and ControlHasIcon =
    { left: string
      right: string }

  and ControlState =
    { isLoading: string }

  and Delete =
    { container: string
      size: StandardSize }

  and Field =
    { container: string
      label: string
      body: string
      hasAddons: FieldHasAddons
      isGrouped: FieldIsGrouped
      layout: FieldLayout }

  and FieldHasAddons =
    { left: string
      centered: string
      right: string
      fullWidh: string }

  and FieldIsGrouped =
    { left: string
      centered: string
      right: string }

  and FieldLayout =
    { isHorizontal: string }

  and Icon =
    { container: string
      size: StandardSize}

  and Input =
    { container: string
      display: InputDisplay
      size: StandardSize
      state: InputState
      color: LevelAndColor
      addon: InputAddon }

  and InputDisplay =
    { isInline: string }

  and InputState =
    { isHovered: string
      isFocused: string
      isActive: string
      isLoading: string }

  and InputAddon =
    { isExpanded: string }

  and Image =
    { container: string
      size: ImageSize
      ratio: ImageRatio }

  and ImageSize =
    { is16x16: string
      is24x24: string
      is32x32: string
      is48x48: string
      is64x64: string
      is96x96: string
      is128x128: string }

  and ImageRatio =
    { isSquare: string
      is1by1: string
      is4by3: string
      is3by2: string
      is16by9: string
      is2by1: string }

  and Heading =
    { title: string
      subtitle: string
      size: HeadingSize
      spacing: HeadingSpacing }

  and HeadingSize =
    { is1: string
      is2: string
      is3: string
      is4: string
      is5: string
      is6: string }

  and HeadingSpacing =
    { isNormal: string }

  and Label =
    { container: string
      size: StandardSize }

  and Progress =
    { container: string
      size: StandardSize
      color: LevelAndColor }

  and Table =
    { container: string
      row: TableRow
      style: TableStyle
      spacing: TableSpacing }

  and TableRow =
    { state: TableRowState }

  and TableRowState =
    { isSelected: string }

  and TableStyle =
    { isBordered: string
      isStripped: string }

  and TableSpacing =
    { isNarrow: string }

  and Tag =
    { container: string
      size: TagSize
      color: LevelAndColor }

  and TagSize =
    { isMedium: string
      isLarge: string }

  and Modifiers =
    { size: StandardSize
      color: LevelAndColor }

  and Bulma =
    { modifiers: Modifiers
      box: Box
      button: Button
      content: Content
      control: Control
      delete: Delete
      field: Field
      heading: Heading
      label: Label
      progress: Progress
      icon: Icon
      image: Image
      input: Input
      table: Table
      tag: Tag }

  let standardSize =
    { isSmall = "is-small"
      isMedium = "is-medium"
      isLarge = "is-large " }

  let levelAndColor =
    { isBlack = "is-black"
      isDark = "is-dark"
      isLight = "is-light"
      isWhite = "is-white"
      isPrimary = "is-primary"
      isInfo = "is-info"
      isSuccess = "is-success"
      isWarning = "is-warning"
      isDanger = "is-danger" }

  let box =
    { container = "box" }

  let button : Button =
    { container = "button"
      size = standardSize
      color = levelAndColor
      state =
        { isHovered = "is-hovered"
          isFocused = "is-focus"
          isActive = "is-active"
          isLoading = "is-loading" }
      styles =
        { isLink = "is-link"
          isOutlined = "is-outlined"
          isInverted = "is-inverted" } }

  let content : Content =
    { container = "content"
      size = standardSize }

  let control : Control =
    { container = "control"
      hasIcon =
        { left = "has-icon-left"
          right = "has-icon-right" }
      state =
        { isLoading = "is-loading" } }

  let delete : Delete =
    { container = "delete"
      size = standardSize }

  let field : Field =
    { container = "field"
      label = "field-label"
      body = "field-body"
      hasAddons =
        { left = "has-addons"
          centered = "has-addons-centered"
          right = "has-addons-right"
          fullWidh = "has-addons-fullwidth" }
      isGrouped =
        { left = "is-grouped"
          centered = "is-grouped-centered"
          right = "is-grouped-right" }
      layout =
        { isHorizontal = "is-horizontal" } }

  let icon : Icon =
    { container = "icon"
      size = standardSize }

  let input : Input =
    { container = "input"
      display =
        { isInline = "is-inline" }
      size = standardSize
      state =
        { isHovered = "is-hovered"
          isFocused = "is-focus"
          isActive = "is-active"
          isLoading = "is-loading" }
      color = levelAndColor
      addon =
        { isExpanded = "is-expanded" } }

  let image : Image =
    { container = "image"
      size =
        { is16x16 = "is-16x16"
          is24x24 = "is-24x24"
          is32x32 = "is-32x32"
          is48x48 = "is-48x48"
          is64x64 = "is-64x64"
          is96x96 = "is-96x96"
          is128x128 = "is-128x128" }
      ratio =
        { isSquare = "is-square"
          is1by1 = "is-1by1"
          is4by3 = "is-4by3"
          is3by2 = "is-3by2"
          is16by9 = "is-16by9"
          is2by1 = "is-2by1" } }

  let heading : Heading =
    { title = "title"
      subtitle = "subtitle"
      size =
        { is1 = "is-1"
          is2 = "is-2"
          is3 = "is-3"
          is4 = "is-4"
          is5 = "is-5"
          is6 = "is-6" }
      spacing =
        { isNormal = "is-spaced" } }

  let label : Label =
    { container = "label"
      size = standardSize }

  let progress : Progress =
    { container = "progress"
      size = standardSize
      color = levelAndColor }

  let table : Table =
    { container = "table"
      row =
        { state =
            { isSelected = "is-selected" } }
      style =
        { isBordered = "is-bordered"
          isStripped = "is-stripped " }
      spacing =
        { isNarrow = "is-narrow" } }

  let tagSize : TagSize =
    { isMedium = "is-medium"
      isLarge = "is-large" }

  let tag : Tag =
    { container = "tag"
      size = tagSize
      color = levelAndColor }

  let bulma =
    { modifiers =
        { size = standardSize
          color = levelAndColor }
      box = box
      button = button
      content = content
      control = control
      delete = delete
      field = field
      icon = icon
      image = image
      input = input
      label = label
      progress = progress
      heading = heading
      table = table
      tag = tag }

  let (++) str1 str2 = str1 + " " + str2
