# Testing of Gilded Rose application

- Comberlato Bampi Julio Alexandre

- David Catrina

- Prüller Marie-Eleonore

## Requirements

For the implementation of the unit tests following (https://github.com/emilybache/GildedRose-Refactoring-Kata/blob/main/GildedRoseRequirements.md) functional requirements where used as a basis for the test cases.

## Test strategy

It was decided to create a test class for each item type having a "unique" behaviour. The implemented tests are aimed at testing edge cases and the items behaviour differing from the "default" items. A test suite for a "default" item was created as well, in order to test the default behaviour of items.

## Difficulties

During the implementation of the tests following difficulties were faced:

- Code duplication: the implemented unit tests are very similar, the usage of an advanced testing framework could avoid code duplication in the test structure.
- Coverage of possible edge cases: the provided requirements hinted at some edge cases, however there is no way of knowing that other edge cases are covered as well.