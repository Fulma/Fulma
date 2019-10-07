### 2.2.0

* Fix #228: Use `button` element for pagination buttons (by @geniuskidkanyi)
* Fix #218: Fix `Columns.IsGap` class generation (by @selketjah)
* Correct doc comments in Card.Footer (by @rmunn)

### 2.1.1

* Add Femto metadata

### 2.1.0

* Make `getCaseName` more robust in .NET (by @alfonsogarciacaro)

### 2.0.1

* Fix #207: Fix SSR by making sure we don't loose the type information (by @dbrattli)

### 2.0.0

* Add `IsSpaced` option to navbar (by @selketjah)
* Fix `Table.IsBordered` generated class (by @tenigma)
* Fix `TextAlignment.Right`
* Fix the generated element for `field-body` and `field-label`
* Release stable version

### 2.0.0-beta-003

* Re-add base classe `title` to headings (by @alfonsogarciacaro)

### 2.0.0-beta-002

* Add Key property to Input (by @forki)
* Fix #183: Field.IsGroupedMultiline missing (by @selketjah)
* Fix #186: Field.IsExpanded is missing from Fulma (by @selketjah)
* Update to Fable.Core 3 (by @alfonsogarciacaro)

### 2.0.0-beta-001

* Reduce bundle size
* Fix #190: Footer should generate a footer element and not a div

### 1.1.0

* Fix column `third` size naming
* Bulma 0.7.2: Add `is-arrowless` to `navbar`
* Bulma 0.7.2: Add ol type support to content
* Bulma 0.7.2: Add `ScreenReaderOnly` to helpers
* Bulma 0.7.2: Add `IsFullheightWithNavbar` to `Hero`
* Bulma 0.7.2: Add button element for `Dropdown` item
* Fix typos comments of `Form.Control.HasIconRight` and `Form.Control.HasIconLeft`
* Remove Font Awesome support from this package

### 1.0.0

* Release stable version for Fable 2
* Fix #161: Replace `Card.Footer.item` with `Card.Footer.a` - `Card.Footer.p` - `Card.Footer.div`

### 1.0.0-beta-026

- Fix Tabs.tab option builder. `CustomClass` and `Modifiers` wasn't added to the generated classes

### 1.0.0-beta-025

- BREAKING CHANGE: `Menu.item` has been replaced with `Menu.Item.a` and `Menu.Item.li`
- Add `Menu.Item.Href` to make it easier to works with hash urls

### 1.0.0-beta-024

- Fix #155: Allow button to have a size and `is-fullwidth` at the same time

### 1.0.0-beta-023

- Add `ValueOrDefault` to `Input` and `Textarea` (by @marcpiechura)

### 1.0.0-beta-022

- Fix typo column doc comment (by @selketjah)

### 1.0.0-beta-021

### 1.0.0-beta-020

- Add missing `Card.image`

### 1.0.0-beta-019

- Add new aspect ratio support for `Image` (since Bulma 0.7.0)
- Add `is-expanded` to `Button` (since Bulma 0.7.0)
- Add modifier supported to Fulma
- `Column.[screen size]` is replace by `Screen.[screen size]`.

### 1.0.0-beta-018

- Add `RequireQualifiedAccess` to `Modifier` API. Needed to avoid conflict with CSSProps

### 1.0.0-beta-017

* Fix typos in `IsStriped` doc comment
* Start supporting Bulma 0.7.x by addingg `has-backgground-xxx` and `has-text-xxx`

### 1.0.0-beta-016

* Fix #126: Add `is-expanded` to `Control`

### 1.0.0-beta-015

* Allow user to define custom color using `IsCustomColor my-color`

### 1.0.0-beta-014

* Fix #120: Simplify namespace
* Remove alternate spelling

### 1.0.0-beta-013

* Add `OnChange` and `Ref` to `Input` and `TextArea`

### 1.0.0-beta-012

* Add `NoColor` to `IColor`
* Fix #114: add `Field.Label.IsNormal`
* Fix #113: fix `Field.Label` API
* Fix #106: provide alternate spelling for some classes `is-fullwidth` - `is-halfheight` - `is-fullwidth`

### 1.0.0-beta-011

* Update dependencies

### 1.0.0-beta-010

* Added missing `CustomClass` to `Media` - `Modal` - `Navbar` - `Pagination` - `Tabs`: https://github.com/MangelMaxime/Fulma/pull/110/files

### 1.0.0-beta-009

* Fix typos in Title docs comment
* Fix typos in Tile docs comment

### 1.0.0-beta-008

* Fix `Table.IsStriped`

### 1.0.0-beta-007

* Fix `IsLoading` signature for the `Control` element

### 1.0.0-beta-006

* Remove small helpers
* Mutualize common properties
* Exposed GenericOption properties
* Remove underscore function
* Avoid computation list usage in user code
* Fix #73: Rework the button element
* Fix #47: Make a review and clean up of the code before releasing Fulma
* Fix #91: Update Bulma to 0.6.x
* Fix #87: Unable to implement modal custom class

### 1.0.0-beta-005

* Don't access Value member in options (update to support future version of Fable)

### 1.0.0-beta-004

* Fix #73: Use static type constraint for the `Button` DSL

### 1.0.0-beta-003

* BREAKING CHANGE: Fix icons display and implement Font Awesome helpers
* Fix #61: Add `is-fullwidth` support for Table element
* Fix #59: Add color support for the navbar component
* Fix #67: Enforce DSL synthax with `[<RequireQualifiedAccess>]` attribute
* BREAKING CHANGE: Fix #70: Make button support different elements. To have the same behavior as before replace `Button.button` with `Button.button_a`

### 1.0.0-beta-001

* Beta is ready for #FableConf ! ! !
* Implements `File` element
* Fix `Field.customClass` && `Field.props` type

### 0.2.0-beta-004

* Implement `Container`
* Implement `Footer`
* Implement `Hero`
* Implement `Section`
* Implement `Tile`
* BREAKING CHANGE: The `grid` module has been removed. You can find the `Columns` wrapper into `Layouts` module
* Fix `Navbar.menu` should generate a `div` not a `span`
* Fix `Navbar.menu` props
* Implements missing feature for `Button`
* Implement `Dropdown`
* Implements basic elements for `Form`

### 0.2.0-beta-003

* Implement `Modal`

### 0.2.0-beta-002

* Fulma is again a netstandard1.6 lib

### 0.2.0-beta-001

* Convert from Fable.Elmish.Bulma to Fulma
* BREAKING CHANGE: Remove `Nav` support as it's deprecated in Bulma. Please use `Navbar` instead
* BREAKING CHANGE: Move to Netstandard 2.0

### 0.1.1

* Implement `Tabs` components with documentation
* Implement `Notification` components with documentation

### 0.1.0-alpha.10

* Fix `Message` colors properties
* Add `Message` documentation
* Add `Size` properties to `Message`
* `Nav` has been dreprecated in Bulma. Users should use `Navbar` from now.
* Remove `FSharp.NET.Sdk` from the dependencies.
* Implement `Navbar` components with documentation
* Implement `Pagination` components with documentation
* Add explanation of how to use and and the architecture. (See Home page)

### 0.1.0-alpha9

* Add `Card` documentation
* Add `Media` documentation
* Add `Menu` documentation
* Add `Button.customClass` alias
* Add `State` to `Menu` declaration in `BulmaClasses`
* Add framework versions to the README.md
* Add `FontAwesome` convenience functions
* Remove `sprintf %s` in favor of the `+` operator (small performance improvments)

### 0.1.0-alpha8

* Fix #19: Refactored BulmaClasses to have more modules and literals
* Updated `bulma` to `Bulma` to give better represantation as module
* Performace improved and generated code reduced by 1800+ lines
* Add breadcrumb support
* Setup babel correctly for the docs site.
* Fix #13 : Move grids into their own namespace

### 0.1.0-alpha7

* Fix typo `typeIsSassword` -> `typeIsPassword`
* Implements `CustomClass` and `Props` for all the helpers

### 0.1.0-alpha6

* Fix #18: Heading should generate `title` by default
* Add Hero support
* Start implemententing `genericOptions`. Related to #16 & #17

### 0.1.0-alpha5

* Add Nav components support

### 0.1.0-alpha4

* Fix #15: Remove duplicate `IsLight`
* Fix `fable` nuget content (add all the **\*.fs files)

### 0.1.0-alpha-3

* Add box
* Add button
* Add content
* Add delete
* Add form
* Add headings
* Add icon
* Add image
* Add progress
* Add table
* Add tag
* Add grid (columns + column)
* Add card
* Add level
* Add media
* Add menu
* Add message
* Add panel

### 0.1.0-alpha-2
* Add icons support

### 0.1.0-alpha-1

* Start project
