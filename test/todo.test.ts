import test from 'ava'

import { todo } from '@seamapi/nextlove-sdk-csharp'

test('todo: returns argument', (t) => {
  t.is(todo('todo'), 'todo', 'returns input')
})
