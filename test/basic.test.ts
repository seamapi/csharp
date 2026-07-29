import test from 'ava'

import { csDoc, csString } from '../codegen/lib/handlebars-helpers.js'

test('basic test', (t) => {
  t.pass()
})

test('csDoc emits escaped C# XML documentation for multiline prose', (t) => {
  t.is(
    csDoc('Use <device> & "account".\nSecond line.'),
    [
      '/// <summary>',
      '/// Use &lt;device&gt; &amp; &quot;account&quot;.',
      '/// Second line.',
      '/// </summary>',
    ].join('\n'),
  )
  t.is(csDoc('  '), '')
})

test('csString escapes schema deprecation messages', (t) => {
  t.is(csString('Use "new" at C:\\sdk'), 'Use \\"new\\" at C:\\\\sdk')
  t.is(csString(), 'Deprecated.')
})
