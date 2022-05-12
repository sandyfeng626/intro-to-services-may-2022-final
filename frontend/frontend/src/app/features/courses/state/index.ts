import {
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
} from '@ngrx/store';
import * as fromCourses from './reducers/courses.reducer';
import * as fromClasses from './reducers/classes.reducer';
export const featureName = 'featureCourses';

export interface CoursesState {
  courses: fromCourses.CoursesState;
  classes: fromClasses.ClassesState;
}

export const reducers: ActionReducerMap<CoursesState> = {
  courses: fromCourses.reducer,
  classes: fromClasses.reducer,
};

const selectFeature = createFeatureSelector<CoursesState>(featureName);

const selectCoursesBranch = createSelector(selectFeature, (f) => f.courses);
const selectClassesBranch = createSelector(selectFeature, (f) => f.classes);

const {
  selectAll: selectAllCoursesArray,
  selectEntities: selectCourseEntities,
} = fromCourses.adapter.getSelectors(selectCoursesBranch);

const { selectEntities: selectAllClassesEntities } =
  fromClasses.adapter.getSelectors(selectClassesBranch);

export const selectAllCourses = selectAllCoursesArray;

export const selectCourseById = (id: string) =>
  createSelector(selectCourseEntities, (entities) => entities[id]);

export const selectClassDatesById = (id: string) =>
  createSelector(
    selectAllClassesEntities,
    (entities) => entities[id]?.offerings
  );
